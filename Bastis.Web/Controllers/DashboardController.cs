using System.Web.Mvc;

namespace Bastis.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboardv1()
        {
            //return View();

            if (User.Identity.IsAuthenticated)
            {
                //if (isAdminUser())
                //{
                return View();
                //}
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            //return View();

        }

        public ActionResult Dashboardv2()
        {
            return View();
        }
    }
}