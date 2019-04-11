using Microsoft.Owin;
using Owin;
using Stripe;

[assembly: OwinStartupAttribute(typeof(EventManage.Startup))]
namespace EventManage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            StripeConfiguration.SetApiKey("sk_test_710GBYxzG4bxy6ZYwyaxv9Uj");

            
        }
       

    }
}
