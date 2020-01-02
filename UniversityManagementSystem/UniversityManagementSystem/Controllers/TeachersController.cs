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
    public class TeachersController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Teachers
        public async Task<ActionResult> Index()
        {
            var teachers = db.Teachers.Include(t => t.Department).Include(t => t.Designation);
            return View(await teachers.ToListAsync());
        }

       

        // GET: Teachers/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName");
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TeacherId,TeacherName,Address,Email,ContactNo,DesignationId,DepartmentId,CreditToBeTaken,RemainingCredit")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                //this is the line which wasted my ONE freaking month :3 
                teacher.RemainingCredit = teacher.CreditToBeTaken;

                db.Teachers.Add(teacher);
                await db.SaveChangesAsync();
                FlashMessage.Confirmation("Teacher Information Saved Successfully");
                return RedirectToAction("Create");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", teacher.DepartmentId);
            ViewBag.DesignationId = new SelectList(db.Designations, "DesignationId", "DesignationName", teacher.DesignationId);
            return View(teacher);
        }

        public JsonResult IsEmailExists(string email)
        {
            var emails = db.Teachers.ToList();

            if (!emails.Any(mail => mail.Email.ToLower() == email.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult IsContactNoExists(string contactNo)
        {
            var contacts = db.Teachers.ToList();

            if (!contacts.Any(contact => contact.ContactNo.ToLower() == contactNo.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        // GET: Teachers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = await db.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Teacher teacher = await db.Teachers.FindAsync(id);
            db.Teachers.Remove(teacher);
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
