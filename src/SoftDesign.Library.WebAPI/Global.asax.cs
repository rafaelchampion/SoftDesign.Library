using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SoftDesign.Library.WebAPI.App_Start;

namespace SoftDesign.Library.WebAPI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();
            UnityMvcActivator.Start();
            SwaggerConfig.Register();
        }
    }
}