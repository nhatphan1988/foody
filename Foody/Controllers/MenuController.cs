using FoodyDomain;
using FoodyDomain.Model;
using System.Web.Mvc;
using System.Linq;
using Foody.Models;


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
            return View("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,ImageUrl")] MenuModel menu)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(menu);
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
