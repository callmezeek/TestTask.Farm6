namespace TestTask.Farm6
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using TestTask.Farm6.Resources;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ClientDataTypeModelValidatorProvider.ResourceClassKey = nameof(Messages);
            DefaultModelBinder.ResourceClassKey = nameof(Messages);
        }
    }
}
