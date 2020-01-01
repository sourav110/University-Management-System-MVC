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
using System.Data.Entity.Migrations;
using Vereyon.Web;

namespace UniversityManagementSystem.Controllers
{
    public class AssignCoursesController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: AssignCourses
        public async Task<ActionResult> Index()
        {
            var assignCourses = db.AssignCourses.Include(a => a.Course).Include(a => a.Department).Include(a => a.Teacher);
            return View(await assignCourses.ToListAsync());
        }


        // GET: AssignCourses/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            //ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName");
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");

            return View();
        }

        // POST: AssignCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AssignCourseId,DepartmentId,TeacherId,CreditToBeTaken,RemainingCredit,CourseId")] AssignCourse assignCourse)
        {
            if (ModelState.IsValid)
            {
                if (IsAssigned(assignCourse))
                {
                    FlashMessage.Danger("This Course is Already Assigned!");
                    return RedirectToAction("Create");
                }

                //assignCourse.Course.IsAssigned = true;

                db.AssignCourses.Add(assignCourse);
                await db.SaveChangesAsync();
                FlashMessage.Confirmation("Successfully Assigned");
                return RedirectToAction("Create");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", assignCourse.DepartmentId);
            //ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "TeacherName", assignCourse.TeacherId);
            //ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", assignCourse.CourseId);

            return View(assignCourse);
        }

        public bool IsAssigned(AssignCourse assign)
        {
            var assignedCourses = db.AssignCourses.ToList();

            if (assignedCourses.Any(c => (c.CourseId == assign.CourseId)))
            {
                return true;
            }
            return false;
        }


        //public JsonResult IsAssigned(int courseId)
        //{
        //    var assignedCourses = db.AssignCourses.ToList();

        //    if(assignedCourses.Any(c => c.AssignCourseId == courseId))
        //    {
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }
        //} 



        public JsonResult GetTeachersByDeptId(int deptId)
        {
            var teachers = db.Teachers.Where(t => t.DepartmentId == deptId).ToList();
            return Json(teachers, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoursesByDeptId(int deptId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == deptId).ToList();
            return Json(courses, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTeachersById(int teacherId)
        {
            Teacher teacher = db.Teachers.FirstOrDefault(t => t.TeacherId == teacherId);
            return Json(teacher, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseById(int courseId)
        {
            Course course = db.Courses.FirstOrDefault(c => c.CourseId == courseId);
            return Json(course, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveAssignCourse(AssignCourse assignCourse)
        {
            var asignCourseList = db.AssignCourses.Where(t => t.CourseId == assignCourse.CourseId && t.Course.IsAssigned == true).ToList();

            if (asignCourseList.Count > 0)
            {
                return Json(false);
            }

            else
            {
                db.AssignCourses.Add(assignCourse);
                db.SaveChanges();


                var teacher = db.Teachers.FirstOrDefault(t => t.TeacherId == assignCourse.TeacherId);
                if (teacher != null)
                {
                    teacher.RemainingCredit = assignCourse.RemainingCredit;

                    db.Teachers.AddOrUpdate(teacher);
                    db.SaveChanges();

                    var course = db.Courses.FirstOrDefault(c => c.CourseId == assignCourse.CourseId);
                    if (course != null)
                    {
                        course.IsAssigned = true;
                        course.AssignedTo = teacher.TeacherName;
                        db.Courses.AddOrUpdate(course);
                        db.SaveChanges();
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }
                return Json(false);
            }
        }


        public ActionResult ViewCourseStatistics()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }
        public ActionResult GetCourseStatisticsByDeptId(int deptId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == deptId).ToList();
            return Json(courses);
        }


        public JsonResult UnAssignAllCourses(bool status)
        {
            var courses = db.Courses.Where(c => c.IsAssigned == true).ToList();
            var enrollCourses = db.EnrollCourses.Where(s => s.IsGraded == true).ToList();
            var teachers = db.AssignCourses.ToList();

            if (courses.Count == 0 && enrollCourses.Count == 0)
            {
                return Json(false);
            }
            else
            {
                foreach (var course in courses)
                {
                    course.IsAssigned = false;
                    course.AssignedTo = "NULL";
                    db.Courses.AddOrUpdate(course);
                    db.SaveChanges();
                }

                foreach (var enrollCourse in enrollCourses)
                {
                    enrollCourse.GradeLetter = null;
                    enrollCourse.IsGraded = false;
                    db.EnrollCourses.AddOrUpdate(enrollCourse);
                    db.SaveChanges();

                }
                foreach (var teacher in teachers)
                {
                    teacher.RemainingCredit = teacher.CreditToBeTaken;
                    teacher.Teacher.RemainingCredit = teacher.CreditToBeTaken;
                    db.AssignCourses.AddOrUpdate(teacher);
                    db.Teachers.AddOrUpdate(teacher.Teacher);
                    db.SaveChanges();
                }

                return Json(true);
            }
        }


        // GET: AssignCourses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignCourse assignCourse = await db.AssignCourses.FindAsync(id);
            if (assignCourse == null)
            {
                return HttpNotFound();
            }
            return View(assignCourse);
        }

        // POST: AssignCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AssignCourse assignCourse = await db.AssignCourses.FindAsync(id);
            db.AssignCourses.Remove(assignCourse);
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
