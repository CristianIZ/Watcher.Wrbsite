using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Safari.UI.Web.Startup))]
namespace Safari.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
