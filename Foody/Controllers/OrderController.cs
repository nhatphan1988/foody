using Foody.Models;
using Foody.Services;
using System.Web;
using System.Web.Mvc;

namespace Foody.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        ICardService _cardService;
        public OrderController(ICardService cardService)
        {
            _cardService = cardService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddDish(Dish dish)
        {
            _cardService.Add(dish);
            return View();
        }

        public ActionResult RemoveDish(Dish dish)
        {
            _cardService.Remove(dish);
            return View();
        }

        public ActionResult GetNumberOfDishes()
        {
            return View(_cardService.Number);
        }
    }
}