

namespace EShop.CORE.Contracts
{
    public interface IGenericManager<T> where T : class
    {
        IApplicationDbContext Context { get; }

        T Add(T entity);
        T GetById(int id);
        T GetById(object[] key);
        T Remove(T entity);
    }
}