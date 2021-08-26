using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LondonDegree_Web.Startup))]
namespace LondonDegree_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
