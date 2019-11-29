using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSnack.Startup))]
namespace WebSnack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
