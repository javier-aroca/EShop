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
    [Authorize]
    public class ShoppingCartController : Controller
    {

       
        IShoppingCartLineManager shoppingCartManager = null;
        IOrderManager orderManager = null;
        IProductManager productManager = null;

        
        /// <summary>
        /// constructor vacio - para unity
        /// </summary>
        public ShoppingCartController() { } 
        
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="shoppingCartManager"></param>
        /// <param name="orderManager"></param>
        /// <param name="productManager"></param>
        public ShoppingCartController(IShoppingCartLineManager shoppingCartManager, IOrderManager orderManager, IProductManager productManager)
        {
            /*context = new ApplicationDbContext();*/
            this.shoppingCartManager = shoppingCartManager; /* new Application.ShoppingCartLineManager(context);*/
            this.productManager = productManager; /*new ProductManager(context);*/
            this.orderManager = orderManager; /* new OrderManager(context);*/
        }


        // GET: ShoppingCart
        /// <summary>
        /// listado de lineas de pedido del usuario
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            var model = shoppingCartManager.GetByUserId(User.Identity.GetUserId())
                .Select(e => new ShoppingCartList 
                { 
                    Id = e.Id,                    
                    Product = e.Product, 
                    Quantity = e.Quantity 
                });

            //ViewBag.Address = "DireccionPorDefecto";
            return View(model);
        }

        // GET: ShoppingCart/Details/5
        /// <summary>
        /// devuelve los detalles de la linea de carrito
        /// </summary>
        /// <param name="id">id del carrito</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var shoppingCart = shoppingCartManager.GetById(id);

                ShoppingCartList model = new ShoppingCartList
                {
                    Id = shoppingCart.Id,
                    Product = shoppingCart.Product,
                    Quantity = shoppingCart.Quantity


                };

                

            return View(model);
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
        /// <summary>
        /// recibe la vista a borrar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var shoppingCart = shoppingCartManager.GetById(id);
            if (shoppingCartManager != null)
            {
                Models.ShoppingCartList model = new Models.ShoppingCartList
                {
                    Id = shoppingCart.Id,
                    Product = shoppingCart.Product,
                    Quantity = shoppingCart.Quantity


                };
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // POST: ShoppingCart/Delete/5
        /// <summary>
        /// envía la vista que se va a borrar
        /// </summary>
        /// <param name="id">id del carrito</param>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var shoppingCart = shoppingCartManager.GetById(id);
                if (shoppingCart != null)
                {
                    shoppingCartManager.Remove(shoppingCart);
                    shoppingCartManager.Context.SaveChanges();
                }

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


        /// <summary>
        /// crea una orden de pedido desde las lineas del carrito
        /// </summary>
        /// <param name="address">direccion para el pedido</param>
        /// <returns></returns>
        public ActionResult CreateOrder(string address)
        {
            
            orderManager.Create(User.Identity.GetUserId(), address, User.Identity.Name);

            return RedirectToAction("Index");
        }
    }
}
