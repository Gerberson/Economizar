using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Economizar.Startup))]
namespace Economizar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
