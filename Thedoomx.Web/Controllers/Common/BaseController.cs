namespace Thedoomx.Web.Controllers.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.AutoMapper;
    using log4net;
    using log4net.Config;
    using Microsoft.AspNet.Identity;

    public abstract class BaseController : Controller
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var language = this.Request.RequestContext.RouteData.Values["lang"].ToString();

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            base.OnActionExecuting(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
//#if (!DEBUG)
            ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            XmlConfigurator.Configure();

            var exception = filterContext.Exception;
            var logMessage = this.GetExceptionInfo(filterContext);

            log.Error(logMessage, exception);

            this.Response.Redirect($"/errors?httpErrorCode=500");

            base.OnException(filterContext);
        }

        private string GetExceptionInfo(ExceptionContext context)
        {
            var lines = new List<string>();

            var userId = context.RequestContext.HttpContext.User == null ? "0" : context.RequestContext.HttpContext.User.Identity.GetUserId();

            lines.Add($"User: {context.HttpContext.User}");
            lines.Add($"UserAgent: {context.HttpContext.Request.UserAgent}");
            lines.Add($"UserIp: {context.HttpContext.Request.UserHostAddress}");
            lines.Add($"UserId: {userId}");

            return string.Join(Environment.NewLine, lines);
        }
    }
}
