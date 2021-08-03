using EShop.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.DAL;
using EShop.CORE.Contracts;

namespace EShop.Application
{
    /// <summary>
    /// manager de pedido
    /// </summary>
    public class OrderManager : GenericManager<Order>, IOrderManager
    {

        /// <summary>
        /// constructor del manager de pedido
        /// </summary>
        /// <param name="context">contexto de datos</param>
        public OrderManager(IApplicationDbContext context) : base(context)
        {

        }

        /// <summary>
        /// retorna los pedidos de un usuario
        /// </summary>
        /// <param name="userId">usuario</param>
        /// <returns>todos los pedidos de un usuario</returns>
        public IQueryable<Order> GetByUserId(string userId)
        {
            return Context.Set<Order>().Where(e => e.UserId == userId);
        }

        /// <summary>
        /// obtiene un pedido con sus lineas de pedido
        /// </summary>
        /// <param name="id">id del pedido</param>
        /// <returns>pedido con sus lineas</returns>
        public Order GetByIdandOrderLines(int id)
        {
            return Context.Set<Order>().Include("OrderLines").Where(i => i.Id == id).FirstOrDefault();
            //TODO: comprobar como sacar todas las lineas de pedido de un pedido con el manager; FirstOrDefault solamente saca una, creo que es quitarlo y tener la lista
        }
    }
}
