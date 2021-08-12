using EShop.CORE;
using EShop.CORE.Contracts;
using EShop.Application; //comprobar si es correcto con application
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EShop.Application
{


    /// <summary>
    /// manager de carrito de compra
    /// </summary>
    public class ShoppingCartLineManager : GenericManager<ShoppingCartLine>, IShoppingCartLineManager
    {

        /// <summary>
        /// constructor del manager de shopping cart de un usuario
        /// </summary>
        /// <param name="context"></param>
        public ShoppingCartLineManager(IApplicationDbContext context) : base(context)
        {

        }


        /// <summary>
        /// metodo que retorna todas las lineas de carrito de un usuario. Si no hay stock suficiente del producto, informa al usuario.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IQueryable<ShoppingCartLine> GetByUserId(string userId)
        {
            return Context.Set<ShoppingCartLine>().Include("Product").Where(e => e.UserId == userId);
        }


        public void AddToCart(int productId, string userId)
        {

            var product = Context.Products.Where(p => p.Id == productId).SingleOrDefault();
            if (product != null && product.Stock>=1)
            {                
                var line = GetByUserId(userId).FirstOrDefault(x => x.ProductId == product.Id);
                if (product.Stock >= 1) { 
                    if (line == null)
                    {
                        CORE.ShoppingCartLine newLine = new CORE.ShoppingCartLine()
                        {
                            UserId = userId,
                            ProductId = productId,
                            Quantity = 1
                        };
                        Add(newLine);
                    }
                    else
                    {

                        line.Quantity++;
                    }
                }
                product.Stock--;
                Context.SaveChanges();
            }
            else
            {
                if (product.Stock == 0)
                {
                    // inicializar las variables para el metodo MessageBox.Show
                    string message = "Stock insuficiente";
                    string caption = "Error";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    // mostrar el MessageBox.
                    result = MessageBox.Show(message, caption, buttons);

                }
                else
                {
                    throw new Exception("Producto no encontrado");
                }
                
            }
        }


    }
}
