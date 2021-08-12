using EShop.CORE;
using EShop.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EShop.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Configuramos seguridad
            ApplicationDbContext context = new ApplicationDbContext();
            RoleManager<IdentityRole> roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("User"))
                roleManager.Create(new IdentityRole("User"));

            ApplicationUser user = userManager.FindByName("admin@admin.com");
            if (user == null)
            {
                user = new ApplicationUser();
                user.UserName = "admin@admin.com";
                user.Email = "admin@admin.com";
                IdentityResult result = userManager.Create(user, "v7KNAnqWwL3#y&9");
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
                else
                {
                    throw new Exception("Usuario no creado");
                }
            }
            else
            {
                //El usuario está creado, ¿Pero ya esta en el rol admin?
                if (!userManager.IsInRole(user.Id, "Admin"))
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
