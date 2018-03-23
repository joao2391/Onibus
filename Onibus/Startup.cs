using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Onibus.Startup))]
namespace Onibus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
