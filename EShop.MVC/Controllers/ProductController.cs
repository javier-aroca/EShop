using EShop.DAL;
using EShop.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.CORE.Contracts;
using Microsoft.AspNet.Identity;

namespace EShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        // TODO: confirmar que debo utilizar las interfaces que hay en contracts 
        /*IApplicationDbContext context = null;*/
        IProductManager productManager = null;
        /*ILogEvent _log = null;*/

        /// <summary>
        /// constructor del controlador de la vista de listado de productos
        /// </summary>
        /// <param name="productManager"></param>
        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        public ProductController()
        {
        }

        
        // GET: Product
        public ActionResult Index()
        {
            var model = new List<ProductList>();

            model.Add(new ProductList{ Id=1,Name="Producto 1", Price=10, Stock=3});
            model.Add(new ProductList { Id = 2, Name = "Producto 2", Price = 15, Stock = 4 });

            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
