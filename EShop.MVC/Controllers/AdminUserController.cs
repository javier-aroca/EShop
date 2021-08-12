using EShop.CORE.Contracts;
using EShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.MVC.Controllers
{
    public class AdminUserController : Controller
    {
        IApplicationDbContext context;
        //ApplicationUserManager applicationUserManager = null;

        public AdminUserController()
        {
            context = new ApplicationDbContext();
            /*this.applicationUserManager = new ApplicationUserManager(context);*/

        }


        // GET: AdminUser
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
