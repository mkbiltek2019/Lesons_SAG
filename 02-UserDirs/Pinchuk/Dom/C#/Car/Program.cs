using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    class Program
    {
        static void Main(string[] args)
        {
            
            SportCar carSpot = new SportCar("Volvo",250);
            Truck truck = new Truck("Haz",60);
            Console.WriteLine("\tSportCarCar\nName:{0}\nMaxSpeed:{1}\nSpeed:{2}\n",carSpot.NameSportCar, carSpot.MaxSpeed,carSpot.Speed);
            Console.WriteLine("\tTruck\nCar Name:{0}\nMaxSpeed:{1}\nSpeed:{2}", truck.Name, truck.MaxSpeed, truck.Speed);
            try
            {
                
                Console.Write("Set new speed SportCar:");
                carSpot.Speed = int.Parse(Console.ReadLine());
                if (carSpot.Speed > carSpot.MaxSpeed)
                {
                    carSpot.GoodCar = false;
                    throw new SpeedOutOfRangeException("SportCar - неробоча");
                }
                Console.Write("Set new speed Truck:");
                truck.Speed = int.Parse(Console.ReadLine());
                if (truck.Speed > truck.MaxSpeed)
                {
                    truck.GoodCar = false;
                    throw new SpeedOutOfRangeException("Truck - неробочий");
                }
                Console.WriteLine("\tSportCarCar\nName:{0}\nMaxSpeed:{1}\nSpeed:{2}\n", carSpot.NameSportCar, carSpot.MaxSpeed, carSpot.Speed);
                Console.WriteLine("\tTruck\nCar Name:{0}\nMaxSpeed:{1}\nSpeed:{2}", truck.Name, truck.MaxSpeed, truck.Speed);
            }
            catch (SpeedOutOfRangeException ex)
            {
                Console.WriteLine("Exception:{0}", ex.msg);
                
            }
            
            
        }
    }
}
