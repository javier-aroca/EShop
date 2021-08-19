using System;

using Unity;
//using Unity.AspNet.Mvc;


namespace EShop.IFR.IoC
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType(Type.GetType("EShop.CORE.Contracts.IApplicationDbContext, EShop.CORE"), Type.GetType("EShop.DAL.ApplicationDbContext, EShop.DAL"), new Unity.AspNet.Mvc.PerRequestLifetimeManager());
            //container.RegisterType(Type.GetType("EShop.CORE.Contracts.IApplicationDbContext, EShop.CORE"),Type.GetType("EShop.DAL.ApplicationDbContext, EShop.DAL"));

            container.RegisterType(Type.GetType("EShop.CORE.Contract.IOrderManager, EShop.CORE"),Type.GetType("EShop.Application.OrderManager, EShop.Application"));

            container.RegisterType(Type.GetType("EShop.CORE.Contract.IProductManager, EShop.CORE"),Type.GetType("EShop.Application.ProductManager, EShop.Application"));

            container.RegisterType(Type.GetType("EShop.CORE.Contract.IShoppingCartLineManager, EShop.CORE"),Type.GetType("EShop.Application.ShoppingCartLineManager, EShop.Application"));

            
            //NOTA: utilizo inyección de dependencias desde MVC ya que desde aquí no puedo implementarlo sin errores.
            
            /*container.RegisterType<IProductManager, ProductManager>();
            container.RegisterType<IShoppingCartLineManager, ShoppingCartLineManager>();
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));//visto en internet*/

            //container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            //container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            //container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}