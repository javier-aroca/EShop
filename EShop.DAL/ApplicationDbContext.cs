using EShop.CORE;
using EShop.CORE.Contracts;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EShop.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        /// <summary>
        /// Metodo estatico para crear el contexto
        /// </summary>
        /// <returns>Contexto de datos</returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        /// <summary>
        /// coleccion persistible de imagenes
        /// </summary>
        public DbSet<Image> Images { get; set; }

        /// <summary>
        /// coleccion persistible de pedidos 
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// coleccion persistible de lineas de pedido
        /// </summary>
        public DbSet<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// coleccion persistible de productos
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// coleccion persistible de lineas de carrito de compras
        /// </summary>
        public DbSet<ShoppingCartLine> ShoppingCartLines { get; set; }
    }
}
