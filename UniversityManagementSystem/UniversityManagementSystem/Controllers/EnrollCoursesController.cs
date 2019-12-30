﻿using System;
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
    public class EnrollCoursesController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: EnrollCourses
        public async Task<ActionResult> Index()
        {
            var enrollCourses = db.EnrollCourses.Include(e => e.Course).Include(e => e.Student);
            return View(await enrollCourses.ToListAsync());
        }

        

        // GET: EnrollCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo");
            return View();
        }

        // POST: EnrollCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EnrollCourseId,StudentId,CourseId,Date,GradeLetter,IsEnroll")] EnrollCourse enrollCourse)
        {
            if (ModelState.IsValid)
            {
                if (IsEnrolled(enrollCourse))
                {
                    FlashMessage.Danger("This Course is Already Enrolled");
                    return RedirectToAction("Create");
                }

                db.EnrollCourses.Add(enrollCourse);
                await db.SaveChangesAsync();
                FlashMessage.Confirmation("Course Enrolled Successfully");
                return RedirectToAction("Create");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", enrollCourse.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "RegNo", enrollCourse.StudentId);
            return View(enrollCourse);
        }


        public bool IsEnrolled(EnrollCourse enroll)
        {
            var enrolledCourses = db.EnrollCourses.ToList();

            //if(enrolledCourses.Any(c => c.CourseId.ToString() == enroll.CourseId.ToString())){
            //    return true;
            //}

            if (enrolledCourses.Any(c => (c.CourseId == enroll.CourseId) && (c.StudentId == enroll.StudentId)))
            {
                return true;
            }

            return false;
        }

        public JsonResult GetStudentByStudentId(int studentId)
        {
            var student = db.Students.FirstOrDefault(s => s.StudentId == studentId);
            return Json(student);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses);
        }

        // GET: EnrollCourses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnrollCourse enrollCourse = await db.EnrollCourses.FindAsync(id);
            if (enrollCourse == null)
            {
                return HttpNotFound();
            }
            return View(enrollCourse);
        }

        // POST: EnrollCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EnrollCourse enrollCourse = await db.EnrollCourses.FindAsync(id);
            db.EnrollCourses.Remove(enrollCourse);
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
