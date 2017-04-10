using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DictWebApp.Startup))]
namespace DictWebApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
