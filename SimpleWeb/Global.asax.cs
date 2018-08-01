using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace SimpleWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            //FilterConfig.Register(GlobalConfiguration.Configuration);
            //WebApiConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Step 2
            // Hooking up configuration for the life of the application
            Database.Configure();
        }        
        protected void Application_BeginRequest()
        {
            Database.OpenSession();
        }
        protected void Application_EndRequest()
        {
            Database.CloseSession();
        }
    }
}
