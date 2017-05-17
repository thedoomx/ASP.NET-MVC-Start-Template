using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Thedoomx.Web.Startup))]
namespace Thedoomx.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
