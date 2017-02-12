using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FestMVC.Startup))]
namespace FestMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
