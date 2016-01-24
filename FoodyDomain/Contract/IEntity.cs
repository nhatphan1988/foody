using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FoodyDomain
{
    public class IEntity
    {
        [Required]
        public string Id { get; set; }
        public string Name{ get; set; }
    }
}
