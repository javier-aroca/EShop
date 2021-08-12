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
    [Authorize(Roles = "Admin")]
    public class AdminProductController : Controller
    {

        IProductManager productManager=null;
        IApplicationDbContext context;


        /// <summary>
        /// constructor del controlador de la vista de administración de productos
        /// </summary>
        public AdminProductController()
        {
            context = new ApplicationDbContext();
            this.productManager = new ProductManager(context);
        }


        // GET: AdminProduct
        /// <summary>
        /// Listado de productos para su administración
        /// </summary>
        /// <returns>ProductList</returns>
        public ActionResult Index()
        {
            var model = productManager.GetAll()
            .Include(e => e.Images)
            .Select(e => new ProductList
            {
                Id = e.Id,
                Name = e.Name,
                Price = e.Price,
                Stock = e.Stock
            });

            return View(model);
        }

        // GET: AdminProduct/Details/5
        /// <summary>
        /// detalle del producto administrado
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var product = productManager.GetById(id);

            if (product != null)
            {
                Models.ProductViewModel model = new Models.ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                };
                return View(model);
            }

            return RedirectToAction("Index");
        }

        // GET: AdminProduct/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminProduct/Create
        /// <summary>
        /// creación de nuevo producto
        /// </summary>
        /// <param name="model">modelo de la vista del producto</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Models.ProductViewModel model)
        {
            try
            {
                CORE.Product product = new CORE.Product
                {

                    Name = model.Name,
                    Price = model.Price,
                    Stock = model.Stock
                };

                productManager.Add(product);
                productManager.Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminProduct/Edit/5
        /// <summary>
        /// obtener los datos a modificar
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var product = productManager.GetById(id);
            if (product != null)
            {
                Models.ProductViewModel model = new Models.ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                };
                return View(model);
            }
            return RedirectToAction("Index");
        } 


        // POST: AdminProduct/Edit/5
        /// <summary>
        /// insertar los nuevos datos a modificar
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <param name="model">modelo de la vista de producto</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, Models.ProductViewModel model)
        {
            try
            {
                var product = productManager.GetById(id);

                if (product != null)
                {
                    product.Id = model.Id;
                    product.Name = model.Name;
                    product.Price = model.Price;
                    product.Stock = model.Stock;

                    productManager.Context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                //TODO: Registar el error a traves de IFR
                ModelState.AddModelError("", "Se ha producido un error contacte con el administrador.");
                return View();
            }
        }

        // GET: Product/Delete/5
        /// <summary>
        /// elimina un producto según us id
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            var product = productManager.GetById(id);
            {
                if (product != null)
                {
                    Models.ProductViewModel model = new Models.ProductViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Stock = product.Stock
                    };
                    return View(model);
                }
                return RedirectToAction("Index");
            }


        }

        // POST: Product/Delete/5
        /// <summary>
        /// elimina un producto
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <param name="model"> modelo de datos de la vista de producto </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, Models.ProductViewModel model)
        {
            try
            {
                var product = productManager.GetById(id);

                if (product != null)
                {
                    productManager.Remove(product);
                    productManager.Context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
