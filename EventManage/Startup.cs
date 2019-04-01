using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventManage.Startup))]
namespace EventManage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
