using System.Web.Mvc;
using SoftDesign.Library.WebAPP.Middleware;

namespace SoftDesign.Library.WebAPP.Controllers
{
    [AuthenticationMiddleware]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}