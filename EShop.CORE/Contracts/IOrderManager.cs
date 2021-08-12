using EShop.CORE;
using System.Linq;

namespace EShop.CORE.Contracts
{
    public interface IOrderManager : IGenericManager<Order>
    {
        Order GetByIdandOrderLines(int id);
        IQueryable<Order> GetByUserId(string userId);

        void Create(string userId, string address);
    }
}