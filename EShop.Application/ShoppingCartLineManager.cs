using EShop.CORE;
using EShop.CORE.Contracts;
using EShop.Application; //comprobar si es correcto con application
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application
{


    /// <summary>
    /// manager de carrito de compra
    /// </summary>
    public class IShoppingCartLineManager : GenericManager<ShoppingCartLine>, CORE.Contracts.IShoppingCartLineManager
    {

        /// <summary>
        /// constructor del manager de shopping cart de un usuario
        /// </summary>
        /// <param name="context"></param>
        public IShoppingCartLineManager(IApplicationDbContext context) : base(context)
        {

        }


        /// <summary>
        /// metodo que retorna todas las lineas de carrito de un usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IQueryable<ShoppingCartLine> GetByUserId(string userId)
        {
            return Context.Set<ShoppingCartLine>().Where(e => e.UserId == userId);
        }


/*        public void AddToCart(Product product, string userId)
        {

            var product = productManager.GetById(idProduct);



            var shoppingCartLineManager = new IShoppingCartLineManager(context);
            var line = shoppingCartLineManager.GetByUserId(context.ShoppingCartLines)

                            shoppingCartLineManager.GetByUserId(User.Identity.GetUserId()).FirstOrDefault(x => x.ProductId == product.Id);
            if (line == null)
            {
                CORE.ShoppingCartLine newLine = new CORE.ShoppingCartLine()
                {
                    UserId = User.Identity.GetUserId(),
                    ProductId = idProduct,
                    Quantity = 1
                };
                shoppingCartLineManager.Add(newLine);
            }
            else
            {

                line.Quantity++;
            }
            shoppingCartLineManager.Context.SaveChanges();

        }*/

        //TODO: 1. obtener el shoppinglistcart de ese usuario y ese producto, 2. obtento 
        /*        public ShoppingCartLine AddToChart(int idProduct)
                {

                    var product = Context.Set<Product>().Where(e => e.Id == idProduct);


                    if (product != null)
                    {
                        ShoppingCartLine line = 
                        *//*var line = shoppingCartManager.GetByUserId(User.Identity.GetUserId()).FirstOrDefault(x => x.ProductId == idProduct);*//*
                        if (line == null)
                        {
                            CORE.ShoppingCartLine newLine = new CORE.ShoppingCartLine()
                            {
                                UserId = User.Identity.GetUserId(),
                                ProductId = idProduct,
                                Quantity = 1
                            };
                            shoppingCartManager.Add(newLine);
                        }
                        else
                        {

                            line.Quantity++;
                        }
                        shoppingCartManager.Context.SaveChanges();
                    }
                    return (line);
                }*/


    }
}
