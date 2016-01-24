using FoodyDomain.App_Code;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodyDomain.Model
{
    public class MenuEntity : IEntity
    { 
        public string Description { get; set; }
        public string Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
