using EShop.CORE;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EShop.CORE.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Image> Images { get; set; }
        DbSet<OrderLine> OrderLines { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ShoppingCartLine> ShoppingCartLines { get; set; }
        int SaveChanges();
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbSet Set(Type entityType);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

    }
}