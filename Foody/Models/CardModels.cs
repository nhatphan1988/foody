using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Foody.Models
{
    public class CardModels
    {
    }

    public class Card
    {
        public Card(Dishes dishes)
        {
            _dishes = dishes;
        }
        public int Number
        {
            get
            {
                return _dishes.Number;
            }
        }
        public int TotalPrice
        {
            get
            {
                return _dishes.TotalPrice;
            }
        }
        private Dishes _dishes;
    }

    public class Dish : MenuModel
    {

    }

    public class Dishes
    {
        private List<Dish> _dishes;
        public Dishes(Dishes dishes)
        {
            _dishes = new List<Dish>();
        }

        public Dishes()
        {
            _dishes = new List<Dish>();
        }
        public void Add(Dish dish)
        {
            _dishes.Add(dish);
        }

        public void Remove(Dish dish)
        {
            _dishes.Remove(dish);
        }

        public int Number { get {
                return _dishes.Count();
            } }
        public int TotalPrice { get; set; }
    }
}