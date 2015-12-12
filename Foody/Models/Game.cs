using System;
using System.Collections.Generic;

namespace Foody.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Name{ get; set; }

        public virtual Student Student{ get; set; }
    }
}
