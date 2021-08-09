using EShop.Application;
using EShop.CORE.Contracts;
using EShop.DAL;
using EShop.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.MVC.Controllers
{
    public class OrderController : Controller
    {

        IOrderManager orderManager = null;
        
        public OrderController()
        {
            IApplicationDbContext context = new ApplicationDbContext();
            this.orderManager = new OrderManager(context);
        }
        


        // GET: Order
        public ActionResult Index()
        {
            var model = orderManager.GetAll()
                .Include(e => e.OrderLines)
                .Select(e => new OrderListModel
                {
                    Id = e.Id,
                    UserId = e.UserId,
                    CreateDate = e.CreateDate,
                    DeliveryAddress = e.DeliveryAddress,
                    Status = e.Status,
                    OrderLines = e.OrderLines
                    

                });

            return View(model);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(Models.OrderListModel model)
        {
            try
            {
                CORE.Order order = new CORE.Order
                {
                    UserId = model.UserId,
                    CreateDate = model.CreateDate,
                    DeliveryAddress = model.DeliveryAddress,
                    Status = model.Status
                    
                };
                orderManager.Add(order);
                orderManager.Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
