using System.Web.Mvc;

namespace Foody.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
