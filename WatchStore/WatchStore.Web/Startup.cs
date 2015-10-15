using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WatchStore.Web.Startup))]
namespace WatchStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
