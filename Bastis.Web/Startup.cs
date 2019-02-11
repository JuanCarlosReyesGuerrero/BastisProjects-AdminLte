using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bastis.Startup))]
namespace Bastis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
