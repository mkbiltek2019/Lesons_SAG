using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    class Truck:Car
    {
        public string Name { get; set; }
        public Truck(string name, int speed)
        {
            this.Name = name;
            this.MaxSpeed = 120 ;
            this.Speed = speed ;
 
        }

    }
}
