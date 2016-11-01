using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FIS.Startup))]
namespace FIS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
