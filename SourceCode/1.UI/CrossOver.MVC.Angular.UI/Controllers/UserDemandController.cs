using System.Web.Mvc;

namespace CrossOver.MVC.Angular.UI.Controllers
{
    public class UserDemandController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "User Demand Book History.";
            return View();
        }
    }
}