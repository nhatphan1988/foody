namespace Foody.Services
{
    //public interface ICardService
    //{
    //    void Add(Dish dish);
    //    void Remove(Dish dish);
    //    int Number {get;}
    //    Dishes Dishes { get; set; }
    //    HttpContextBase HttpContext { get; set; }
    //}
    //public class CardService:ICardService
    //{
    //    public HttpContextBase HttpContext { get; set; }
    //    public Dishes Dishes { get; set; }

    //    public CardService(HttpContextBase httpContext)
    //    {
    //        HttpContext = httpContext;
    //    }

    //    public void Add(Dish dish)
    //    {
    //        Dishes = HttpContext.Session["__Dishes"] as Dishes;
    //        if(Dishes==null)
    //        {
    //            Dishes = new Dishes();
    //        }
    //        Dishes.Add(dish);
    //        HttpContext.Session["__Dishes"] = Dishes;
    //    }

    //    public void Remove(Dish dish)
    //    {
    //        Dishes = HttpContext.Session["__Dishes"] as Dishes;
    //        if (Dishes == null)
    //        {
    //            Dishes = new Dishes();
    //        }
    //        Dishes.Remove(dish);
    //        HttpContext.Session["__Dishes"] = Dishes;
    //    }

    //    public int Number
    //    {
    //        get
    //        {
    //            return (HttpContext.Session["__Dishes"] as Dishes).Number;
    //        }
    //    }

    //    public int TotalPrice
    //    {
    //        get
    //        {
    //            return (HttpContext.Session["__Dishes"] as Dishes).TotalPrice;
    //        }
    //    }
    //}
}