using System.Web.Mvc;

namespace Bastis.Controllers
{
    public class ConfigurationController : Controller
    {
        // GET: Configuration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cities()
        {
            return View();
        }

        public ActionResult States()
        {
            return View();
        }

        public ActionResult Permissions()
        {
            return View();
        }

        public ActionResult Menus()
        {
            return View();
        }
    }
}