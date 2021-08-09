using EShop.Application;
using EShop.CORE;
using EShop.CORE.Contracts;
using EShop.DAL;
using EShop.MVC.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShop.MVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        CORE.Contracts.IShoppingCartLineManager shoppingCartManager = null;
        IProductManager productManager;

        public ShoppingCartController()
        {
            IApplicationDbContext context = new ApplicationDbContext();
            this.shoppingCartManager = new Application.ShoppingCartLineManager(context);
            this.productManager = new ProductManager(context);
        }

        //Cuando tengamos IOC este constructor será el único que tendremos
        //public ShoppingCartController( IShoppingCartLineManager shoppingCartManager)
        //{
        //    this.shoppingCartManager = shoppingCartManager;
        //}


        // GET: ShoppingCart
        public ActionResult Index()
        {

            var model = shoppingCartManager.GetByUserId(User.Identity.GetUserId())
                .Select(e => new ShoppingCartList 
                { 
                    Id = e.Id,                    
                    Product = e.Product, 
                    Quantity = e.Quantity 
                });

            
            return View(model);
        }

        // GET: ShoppingCart/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingCart/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingCart/Create
        [HttpPost]

        public ActionResult Create(Models.ShoppingCartList model)
        {
            try
            {
                CORE.ShoppingCartLine shoppingCartLine = new CORE.ShoppingCartLine
                {
                    Product = model.Product,
                    Quantity = model.Quantity,
                    UserId = User.Identity.GetUserId()
                };
                shoppingCartManager.Add(shoppingCartLine);
                shoppingCartManager.Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




/*        public ActionResult Create(FormCollection collection)
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
        }*/

        // GET: ShoppingCart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingCart/Edit/5
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

        // GET: ShoppingCart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingCart/Delete/5
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

        public ActionResult SubstractFromCartView(int idProduct)
        {
            return View();
        }



    }
}
