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
    public class AllocatedClassroomsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: AllocatedClassrooms
        public async Task<ActionResult> Index()
        {
            var allocatedClassroms = db.AllocatedClassroms.Include(a => a.Course).Include(a => a.Day).Include(a => a.Department).Include(a => a.Room);
            return View(await allocatedClassroms.ToListAsync());
        }

        

        // GET: AllocatedClassrooms/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode");
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayName");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNo");
            return View();
        }

        // POST: AllocatedClassrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AllocatedClassroomId,DepartmentId,CourseId,RoomId,DayId,FromTime,ToTime,AllocationStatus")] AllocatedClassroom allocatedClassroom)
        {
            if (ModelState.IsValid)
            {
                allocatedClassroom.IsAllocated = true;

                db.AllocatedClassroms.Add(allocatedClassroom);
                await db.SaveChangesAsync();
                FlashMessage.Confirmation("Room Successfully Allocated");
                return RedirectToAction("Create");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseCode", allocatedClassroom.CourseId);
            ViewBag.DayId = new SelectList(db.Days, "DayId", "DayName", allocatedClassroom.DayId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", allocatedClassroom.DepartmentId);
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNo", allocatedClassroom.RoomId);
            return View(allocatedClassroom);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = db.Courses.Where(c => c.DepartmentId == departmentId).ToList();
            return Json(courses);
        }

        // GET: AllocatedClassrooms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllocatedClassroom allocatedClassroom = await db.AllocatedClassroms.FindAsync(id);
            if (allocatedClassroom == null)
            {
                return HttpNotFound();
            }
            return View(allocatedClassroom);
        }

        // POST: AllocatedClassrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AllocatedClassroom allocatedClassroom = await db.AllocatedClassroms.FindAsync(id);
            db.AllocatedClassroms.Remove(allocatedClassroom);
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
