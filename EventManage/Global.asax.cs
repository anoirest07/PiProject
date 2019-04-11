using EventManage.Models;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EventManage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        string con = ConfigurationManager.ConnectionStrings["EventDB"].ConnectionString;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            StripeConfiguration.SetApiKey(ConfigurationManager.AppSettings["stripeSecretKey"]);
            SqlDependency.Start(con);


        }
        protected void Session_Start(object sender, EventArgs e)
        {
            int Id = 1;
            NotificationComponent NC = new NotificationComponent();
            var currentTime = DateTime.Now;
            HttpContext.Current.Session["LastUpdated"] = currentTime;

            //Id = Int32.Parse(User.Identity.GetUserId());


            NC.RegisterNotification(currentTime);


        }
        protected void Application_End()
        {
            //here we will stop Sql Dependency
            SqlDependency.Stop(con);
        }
    }
}
