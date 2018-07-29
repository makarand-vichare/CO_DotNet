using System.Web.Mvc;

namespace CrossOver.MVC.Angular.UI.Controllers
{
    public class SearchBookController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Search Book.";
            return View();
        }

    }
}