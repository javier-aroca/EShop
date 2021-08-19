using EShop.CORE;
using EShop.CORE.Contracts;
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
        /// metodo que retorna todas las lineas de carrito de un usuario logeado. Si no hay stock suficiente del producto, informa al usuario.
        /// </summary>
        /// <param name="userId">usuario</param>
        /// <returns></returns>
        public IQueryable<ShoppingCartLine> GetByUserId(string userId)
        {
            return Context.Set<ShoppingCartLine>().Include("Product").Where(e => e.UserId == userId);
        }


        /// <summary>
        /// añade un producto al carrito del cliente
        /// </summary>
        /// <param name="productId">id del producto</param>
        /// <param name="userId">id del usuario</param>
        public void AddToCart(int productId, string userId)
        {

            var product = Context.Products.Where(p => p.Id == productId).SingleOrDefault();

            if (userId != null)//existe el usuario
            {

                if (product != null && product.Stock >= 1)//existe el producto y hay stock
                {
                    var line = GetByUserId(userId).FirstOrDefault(x => x.ProductId == product.Id);
                    if (product.Stock >= 1)
                    {
                        if (line == null)//hay stock pero no hay linea de carrito
                        {
                            CORE.ShoppingCartLine newLine = new CORE.ShoppingCartLine()
                            {
                                UserId = userId,
                                ProductId = productId,
                                Quantity = 1
                            };
                            Add(newLine);
                        }
                        else //añado una unidad al producto
                        {

                            line.Quantity++;
                        }
                    }
                    product.Stock--;//elimino una unidad del stock
                    Context.SaveChanges();//guardo cambios
                }
                else
                {
                    if (product.Stock == 0)//no hay stock y muestro mensaje de error de stock
                    {
                        // inicializar las variables para el metodo MessageBox.Show
                        string message = "Stock insuficiente";
                        string caption = "Error";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result;

                        // mostrar el MessageBox.
                        result = MessageBox.Show(message, caption, buttons);

                    }
                    else//no hay producto
                    {
                        throw new Exception("Producto no encontrado");
                    }

                }
            }
            else//usuario no existe y muestro error de login
            {
                // inicializar las variables para el metodo MessageBox.Show
                string message = "Es necesario iniciar sesión para reservar productos";
                string caption = "Error";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // mostrar el MessageBox.
                result = MessageBox.Show(message, caption, buttons);
            }
        }


    }
}
