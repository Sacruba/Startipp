using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StarTipp.Startup))]
namespace StarTipp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
