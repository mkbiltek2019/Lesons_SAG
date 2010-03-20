using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars
{
    class SportCar : Car
    {
        private string nameSportCar;

        public string NameSportCar
        {
            get;
            set;
        }

        public SportCar(string name, int speed)
        {
            this.NameSportCar = name;
            this.MaxSpeed = 250;
            this.Speed = speed;
        }
    }
}
