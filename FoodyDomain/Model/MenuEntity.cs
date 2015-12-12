using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodyDomain.Model
{
    public class MenuEntity:IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
        public int Number { get; set; }
    }
}
