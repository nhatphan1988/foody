using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodyRespository.Model
{
    public class Restaurant : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
