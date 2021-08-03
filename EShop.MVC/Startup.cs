using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EShop.MVC.Startup))]
namespace EShop.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
