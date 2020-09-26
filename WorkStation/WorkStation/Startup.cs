using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkStation.Startup))]
namespace WorkStation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
