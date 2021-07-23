using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EShop.Web.Startup))]
namespace EShop.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
