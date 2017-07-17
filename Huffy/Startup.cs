using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Huffy.Startup))]
namespace Huffy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
