using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodyRespository.Model
{
    public class Dish : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
