namespace Thedoomx.Web.Controllers
{
    using System.Web.Mvc;
    using Common;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
