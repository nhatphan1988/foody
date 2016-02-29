using System.Web.Mvc;

namespace Foody.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult About()
        {
            return View("About");
        }   

        public ActionResult Difference()
        {
            return View("Difference");
        }
        
    }
    
}
