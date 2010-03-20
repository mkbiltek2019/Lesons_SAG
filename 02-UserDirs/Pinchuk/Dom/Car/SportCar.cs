using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    class SportCar:Car
    {
        public string NameSportCar{ get; set; }               
        public SportCar(string name,int speed)
        {
            this.NameSportCar = name;
            this.MaxSpeed = 300;
            this.Speed = speed;
        }

    }
}
