using EShop.CORE;
using EShop.CORE.Contracts;
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
        /// metodo que retorna todas las lineas de carrito de un usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IQueryable<ShoppingCartLine> GetByUserId(string userId)
        {
            return Context.Set<ShoppingCartLine>().Where(e => e.UserId == userId);
        }


    }
}
