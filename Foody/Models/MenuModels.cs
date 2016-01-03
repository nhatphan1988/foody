using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Foody.Models
{
    public class MenuModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public HttpPostedFileBase ImageUrl { get; set; }
    }
}