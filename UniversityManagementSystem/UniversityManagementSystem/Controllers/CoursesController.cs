using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Models;
using Vereyon.Web;

namespace UniversityManagementSystem.Controllers
{
    public class CoursesController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Courses
        public async Task<ActionResult> Index()
        {
            var courses = db.Courses.Include(c => c.Department).Include(c => c.Semester);
            return View(await courses.ToListAsync());
        }


        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterNo");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CourseId,CourseCode,CourseName,Credit,Description,DepartmentId,SemesterId,AssignTo,IsEnroll")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                await db.SaveChangesAsync();
                FlashMessage.Confirmation("Course Saved Successfully");
                return RedirectToAction("Create");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", course.DepartmentId);
            ViewBag.SemesterId = new SelectList(db.Semesters, "SemesterId", "SemesterNo", course.SemesterId);
            return View(course);
        }


        public JsonResult IsCodeExists(string courseCode)
        {
            var courses = db.Courses.ToList();
            
            if(!courses.Any(code => code.CourseCode.ToLower() == courseCode.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult IsNameExists(string courseName)
        {
            var courses = db.Courses.ToList();

            if (!courses.Any(code => code.CourseName.ToLower() == courseName.ToLower()))

            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }



        // GET: Courses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = await db.Courses.FindAsync(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Course course = await db.Courses.FindAsync(id);
            db.Courses.Remove(course);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
