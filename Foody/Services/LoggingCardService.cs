using System;
using System.Web;
using Foody.Models;

namespace Foody.Services
{
    public class LoggingCardService : ICardService
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ICardService CardService { get; set; }

        public LoggingCardService(ICardService cardservice)
        {
            CardService = cardservice;
        }

        public Dishes Dishes
        {
            get
            {
                return CardService.Dishes;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public HttpContextBase HttpContext
        {
            get
            {
                return CardService.HttpContext;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Number
        {
            get
            {
                return CardService.Number;
            }
        }

        public void Add(Dish dish)
        {
            logger.Info("Add Dish");
            CardService.Add(dish);
        }

        public void Remove(Dish dish)
        {
            logger.Info("Remove Dish");
            CardService.Remove(dish);
        }
    }

}