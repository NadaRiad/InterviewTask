using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3.DAL;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeSystemContext db = new EmployeeSystemContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employee.Where(m=>m.IsActive==true).ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            return RedirectToAction("Index");
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
          return  PartialView("_AddEmployee");
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,BirthDate,Photo,JopTitle")] Employee employee, HttpPostedFileBase photo)
        {
            if (photo != null)
            {
                string pic = System.IO.Path.GetFileName(photo.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/images/"), pic);
                photo.SaveAs(path);
                employee.Photo = "images/" + pic;
                employee.IsActive = true;
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                employee.IsActive = true;
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("index");

            }

           
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return PartialView("_EditEmployee",employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age,BirthDate,Photo,JopTitle")] Employee employee, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    string pic = System.IO.Path.GetFileName(photo.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/images/"), pic);
                    photo.SaveAs(path);
                    employee.Photo = "images/" + pic;
                }

                    db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            Employee employee = db.Employee.Find(id);
            employee.IsActive = false;
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
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
