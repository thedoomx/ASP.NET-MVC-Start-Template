using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Thedoomx.Web.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult Index(int? httpErrorCode)
        {
            switch (httpErrorCode)
            {
                case 404:
                    return this.RedirectToAction("Error404");

                case 500:
                    return this.RedirectToAction("Error500");

                default:
                    return this.RedirectToAction("UnhandledError");
            }
        }

        public ActionResult Error404()
        {
            return this.View("Error404");
        }

        public ActionResult Error500()
        {
            return this.View("Error500");
        }

        public ActionResult UnhandledError()
        {
            return this.View("UnhandledError");
        }
    }
}