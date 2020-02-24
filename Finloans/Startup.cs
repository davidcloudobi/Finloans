using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Finloans.Startup))]
namespace Finloans
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
