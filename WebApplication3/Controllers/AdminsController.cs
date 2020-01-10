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
    public class AdminsController : Controller
    {
        private EmployeeSystemContext db = new EmployeeSystemContext();

        public ActionResult Login()
        {
            return View();
                }
        [HttpPost]
        public ActionResult Login(Admin Account)
        {
            var admin = db.Admins.Where(m => m.Email == Account.Email && m.Password == Account.Password).FirstOrDefault();
            if (admin != null)
            {
                Session["UserID"] = admin.ID;
                Session["UserName"] = admin.UserName;
                 
                return RedirectToAction("Index", "Employees");
            }
            else return View("Login");
        }


        public ActionResult LogOut()
        {
            Session["UserID"] = null;
            Session["UserName"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult Register()
        {
            Session["Confirm"] = true;
            return View();
        }
        [HttpPost]
        public ActionResult Register(Admin model,string ConfirmPassword)
        {
            if (ModelState.IsValid)
            {
                Admin NewAdmin = new Admin();
                NewAdmin = model;
                db.Admins.Add(NewAdmin);
                db.SaveChanges();
                Session["Confirm"]=true;
                return RedirectToAction("Login");
            }
            Session["Confirm"] = false;
            return View();

        }
            // GET: Admins
            public ActionResult Index()
        {
            return View(db.Admins.ToList());
        }

        
     
        public ActionResult Create()
        {
            return PartialView("_AddAdmin");
        }

             [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Password,Email")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

       
    }
}
