using EShop.DAL;
using EShop.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShop.CORE.Contracts;
using Microsoft.AspNet.Identity;
using EShop.Application;
using System.Data.Entity;

namespace EShop.MVC.Controllers
{
    public class ProductController : Controller
    {
        // TODO: confirmar que debo utilizar las interfaces que hay en contracts 
        /*IApplicationDbContext context = null;*/
        IProductManager productManager = null;
        /*ILogEvent _log = null;*/
        IApplicationDbContext context;
        IShoppingCartLineManager shoppingCartLineManager;

/*        /// <summary>
        /// constructor del controlador de la vista de listado de productos
        /// </summary>
        /// <param name="productManager"></param>
       public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }*/

        public ProductController()
        {
            context = new ApplicationDbContext();
            this.productManager = new ProductManager(context);
            this.shoppingCartLineManager = new ShoppingCartLineManager(context);
        }

        
        // GET: Product
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

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = productManager.GetById(id);

            if (product!=null)
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

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
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

        // GET: Product/Edit/5
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

        // POST: Product/Edit/5
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


        public ActionResult AddToCartView(int idProduct)
        {
            shoppingCartLineManager.AddToCart(idProduct, User.Identity.GetUserId());
            //var product = productManager.GetById(idProduct);

            //if (product != null)
            //{
            //    var shoppingCartLineManager = new Application.IShoppingCartLineManager(context);
            //    var line = shoppingCartLineManager.GetByUserId(User.Identity.GetUserId()).FirstOrDefault(x => x.ProductId == idProduct);
            //    if (line == null)
            //    {
            //        CORE.ShoppingCartLine newLine = new CORE.ShoppingCartLine()
            //        {
            //            UserId = User.Identity.GetUserId(),
            //            ProductId = idProduct,
            //            Quantity = 1,

            //        };
            //        shoppingCartLineManager.Add(newLine);
            //    }
            //    else
            //    {

            //        line.Quantity++;
            //    }
            //    shoppingCartLineManager.Context.SaveChanges();
            //}


            return RedirectToAction("Index");

        }
    }
}
