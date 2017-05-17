namespace Thedoomx.Web
{
    using System;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Infrastructure.AutoMapper;
    using log4net.Config;
    using Thedoomx.Web.App_Start;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.RegisterAutofac();

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());

            XmlConfigurator.Configure();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
#if !DEBUG
            var exception = this.Server.GetLastError() as HttpException;

            if (exception != null)
            {
                var httpCode = exception.GetHttpCode();

                this.Response.Redirect($"/Errors?httpErrorCode={httpCode}");
            }
#endif
        }
    }
}
