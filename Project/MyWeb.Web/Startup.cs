using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWeb.Web.Startup))]
namespace MyWeb.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
