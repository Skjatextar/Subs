using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Subs.Startup))]
namespace Subs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
