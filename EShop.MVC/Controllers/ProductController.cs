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
        IProductManager productManager = null;
        IShoppingCartLineManager shoppingCartLineManager = null;

/*        /// <summary>
        /// constructor del controlador de la vista de listado de productos
        /// </summary>
        /// <param name="productManager"></param>
       public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }*/

        /// <summary>
        /// constructor vacio 
        /// </summary>
        public ProductController() { } 
        
        /// <summary>
        /// constructor de producto
        /// </summary>
        /// <param name="productManager">mnager de producto</param>
        /// <param name="shoppingCartLineManager"></param>
        public ProductController(IProductManager productManager, IShoppingCartLineManager shoppingCartLineManager)
        {
            
            this.productManager = productManager; 
            this.shoppingCartLineManager = shoppingCartLineManager; 
        }

        
        // GET: Product
        /// <summary>
        /// lista los productos en la tienda
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            var result = new List<CORE.Product>();
            

            try //gestión de errores al listar productos
            {
                result = productManager.GetAll().ToList();
                ViewBag.Status = "Ok";
                
            }
            catch(Exception e)
            {
                ViewBag.Status = "Error";
                
            }

            return View(result);

        }

        // GET: Product/Details/5
        /// <summary>
        /// detalle de producto
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var product = new CORE.Product();
            try
            {
                product = productManager.GetById(id);
                ViewBag.Status = "Ok";
            }
            catch (Exception e)
            {
                ViewBag.Status = "Error";
                
            }

            if (product!=null)//existe
            {
                Models.ProductViewModel model = new Models.ProductViewModel //nuevo modelo con los datos del producto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                };
                return View(model);
            }

            return RedirectToAction("Index");//vuelvo al listado
        }

        // GET: Product/Create
        /// <summary>
        /// crea nuevo producto
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        /// <summary>
        /// crea un nuevo producto 
        /// </summary>
        /// <param name="model">modelo de datos de producto</param>
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

                productManager.Add(product);//añado el producto
                productManager.Context.SaveChanges();//guardo el contexto en base de datos

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        /// <summary>
        /// modifica un producto
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var product = productManager.GetById(id);
            if (product != null)//existe
            {
                Models.ProductViewModel model = new Models.ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                };
                return View(model);//devuelvo vista con los nuevos datos
            }
            return RedirectToAction("Index");


        }

        // POST: Product/Edit/5
        /// <summary>
        /// modifica un producto
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, Models.ProductViewModel model)
        {
            try
            {
                var product = productManager.GetById(id);

                if (product != null)//existe
                {
                    product.Id = model.Id;
                    product.Name = model.Name;
                    product.Price = model.Price;
                    product.Stock = model.Stock;

                    productManager.Context.SaveChanges();//guardo cambios en base de datos
                }

                return RedirectToAction("Index");//vuelvo a la vista principal de productos
            }
            catch
            {
                ModelState.AddModelError("", "Se ha producido un error contacte con el administrador.");
                return View();
            }
        }

        // GET: Product/Delete/5
        /// <summary>
        /// borra un producto
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
                return RedirectToAction("Index"); //vuelvo a la vista principal de productos
            }

            
        }

        // POST: Product/Delete/5
        /// <summary>
        /// borra un producto
        /// </summary>
        /// <param name="id">id del producto</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, Models.ProductViewModel model)
        {
            try
            {
                var product = productManager.GetById(id);

                if (product != null)//existe
                {
                    productManager.Remove(product);//elimino
                    productManager.Context.SaveChanges();//guardo en base de datos
                }

                return RedirectToAction("Index");//vuelvo a index de producto
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        /// añade la cantidad del producto al carrito.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpPost]
        public ActionResult AddToCart(int id, int quantity)
        {


            for (int i = 1; i<= quantity; i++) 
            {
                shoppingCartLineManager.AddToCart(id, User.Identity.GetUserId());//llamo al metodo AddToCart una vez por cada cantidad a añadir.
            }
            return RedirectToAction("Index");

        }

    }
}
