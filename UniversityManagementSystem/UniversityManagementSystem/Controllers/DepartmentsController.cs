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
    public class DepartmentsController : Controller
    {
        private ProjectDbContext db = new ProjectDbContext();

        // GET: Departments
        public async Task<ActionResult> Index()
        {
            return View(await db.Departments.ToListAsync());
        }

       

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DepartmentId,DepartmentCode,DepartmentName")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                await db.SaveChangesAsync();
                FlashMessage.Confirmation("Department Saved Successfully");
                return RedirectToAction("Create");
            }

            return View(department);
        }


        public JsonResult IsCodeExists(string departmentCode)
        {
            var departments = db.Departments.ToList();

            if (!departments.Any(code => code.DepartmentCode.ToLower() == departmentCode.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult IsNameExists(string departmentName)
        {
            var departments = db.Departments.ToList();

            if(!departments.Any(name => name.DepartmentName.ToLower() == departmentName.ToLower()))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }



        // GET: Departments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = await db.Departments.FindAsync(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Department department = await db.Departments.FindAsync(id);
            db.Departments.Remove(department);
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
