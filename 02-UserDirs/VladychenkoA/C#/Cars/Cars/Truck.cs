using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars
{
    class Truck : Car
    {
        private string nameTruck;

        public string NameTruck
        {
            get;
            set;
        }

        public Truck(string name, int speed)
        {
            this.NameTruck = name;
            this.MaxSpeed = 120;
            this.Speed = speed;
        }
    }
}
