using FoodyDomain;
using FoodyDomain.Model;
using System.Web.Mvc;
using System.Linq;

namespace Foody.Controllers
{
    public class MenuController : Controller
    {
        private IResponsitory<MenuEntity> _menuResponsitory;
        public MenuController(IResponsitory<MenuEntity> menuResponsitory)
        {
            _menuResponsitory = menuResponsitory;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _MenuPartial()
        {
            var menus = _menuResponsitory.List;
            return PartialView("_MenuPartial",menus);
        }

        [HttpPost]
        public ActionResult SearchMenuName(string menuName)
        {
            var menus = _menuResponsitory.List.Where(s=>s.Name.ToLower().Contains(menuName.ToLower())).ToList();
            return View("_MenuPartial",menus);
        }
    }
}
