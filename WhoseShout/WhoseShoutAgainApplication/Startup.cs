using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhoseShoutAgainApplication.Startup))]
namespace WhoseShoutAgainApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
