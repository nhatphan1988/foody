using FoodyDomain.App_Code;
using System.ComponentModel.DataAnnotations;

namespace FoodyDomain.Model
{
    public class MenuEntity : IEntity
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
