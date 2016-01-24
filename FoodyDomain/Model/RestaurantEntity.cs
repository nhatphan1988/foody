using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodyDomain.Model
{
    public class RestaurantEntity:IEntity
    {
        public string Description { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public string MenuId { get; set; }
    }
}
