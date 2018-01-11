using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DemoShop.WebUI.Startup))]
namespace DemoShop.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
