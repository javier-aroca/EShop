using EShop.CORE;
using System.Linq;

namespace EShop.CORE.Contracts
{
    public interface IShoppingCartLineManager : IGenericManager<ShoppingCartLine>
    {
        IQueryable<ShoppingCartLine> GetByUserId(string userId);
    }
}