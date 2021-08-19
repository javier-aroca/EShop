using EShop.Application;
using EShop.CORE.Contracts;
using EShop.DAL;
using EShop.MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.MVC.Controllers
{
    [Authorize] //usuarios registrados
    public class OrderController : Controller
    {

        IOrderManager orderManager = null;
        
        //public OrderController() { } //test
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="orderManager">manager de pedido</param>
        public OrderController(IOrderManager orderManager)
        {
            
            this.orderManager = orderManager; 
        }
        


        // GET: Order
        /// <summary>
        /// listado de pedidos incluyendo lineas de pedido
        /// </summary>
        /// <returns>vista con el modelo</returns>
        public ActionResult Index()
        {
            var model = orderManager.GetByUserId(User.Identity.GetUserId())
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
        /// <summary>
        /// detalle de un pedido
        /// </summary>
        /// <param name="id">id del pedido</param>
        /// <returns>vista del modelo</returns>
        public ActionResult Details(int id)
        {
            var order = orderManager.GetById(id);

            Models.OrderViewModel model = new Models.OrderViewModel
            {
                Id = order.Id,
                
                CreateDate = order.CreateDate,
                DeliveryAddress = order.DeliveryAddress,
                Status = order.Status,
                OrderLines = order.OrderLines
            };

            return View(model);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        /// <summary>
        /// crear un pedido
        /// </summary>
        /// <param name="model">modelo del nuevo pedido</param>
        /// <returns></returns>
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
        /// <summary>
        /// elimina un pedido
        /// </summary>
        /// <param name="id">id del pedido</param>
        /// <param name="collection"></param>
        /// <returns></returns>
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
