using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InspireTools.Startup))]
namespace InspireTools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
