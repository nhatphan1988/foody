using FoodyDomain.Model;
using FoodyRespository.Respository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Foody.Controllers
{
    public class RestaurantController : Controller
    {
        FoodyDomain.IResponsitory<RestaurantEntity> _restaurantResponsitory;
        public RestaurantController()
        {
            _restaurantResponsitory = new RestaurantResponsitory();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _MenuPartial()
        {
            List<RestaurantEntity> restaurants = (List<RestaurantEntity>)_restaurantResponsitory.List;
            return PartialView(restaurants);
        }
    }
}
