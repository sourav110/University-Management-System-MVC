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
    public class StudentsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Students
        public async Task<ActionResult> Index()
        {
            var students = db.Students.Include(s => s.Department);
            return View(await students.ToListAsync());
        }

        
        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentId,StudentName,Email,ContactNo,RegistrationDate,Address,DepartmentId,RegNo")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.RegNo = GenerateRegNo(student);
                db.Students.Add(student);
                await db.SaveChangesAsync();
                FlashMessage.Confirmation("Student Registered Successfully! " +
                    "\nRegistration No is " + student.RegNo + 
                    "\nStudent Name :" + student.StudentName + 
                    "\nEmail : " + student.Email + 
                    "\nContact No : " + student.ContactNo + 
                    "\nDepartment : " + student.Department.DepartmentCode +
                    "\nRegistration Date : " + student.RegistrationDate);
                return RedirectToAction("Create");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentCode", student.DepartmentId);
            return View(student);
        }

        private string GenerateRegNo(Student student)
        {
            int id = db.Students.Count(s => (s.DepartmentId == student.DepartmentId)
                                            && (s.RegistrationDate.Year == student.RegistrationDate.Year)) + 1;

            Department department = db.Departments.Where(d => d.DepartmentId == student.DepartmentId).FirstOrDefault();
            string regNum = department.DepartmentCode + "-" + student.RegistrationDate.Year + "-" + id.ToString("000");
            return regNum;
        }

        //Unique checking
        public JsonResult IsEmailExists(string email)
        {
            var emails = db.Students.ToList();
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
            var contacts = db.Students.ToList();
            if (!contacts.Any(contact => contact.ContactNo.ToLower() == contactNo.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Student student = await db.Students.FindAsync(id);
            db.Students.Remove(student);
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
