using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shopapp.Startup))]
namespace shopapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
