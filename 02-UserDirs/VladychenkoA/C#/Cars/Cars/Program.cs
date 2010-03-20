using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            SportCar sportCar = new SportCar("Ferrari", 245);
            Truck truck = new Truck("Maz", 105);
            Console.WriteLine("\n\n\n\n\n\tСпортКар \tИмя: {0}\n\t\t\tМаксимальная скорость: {1} \n\t\t\tСкорость: {2}", sportCar.NameSportCar, sportCar.MaxSpeed, sportCar.Speed);
            Console.WriteLine("\n\n\tТрак \t\tИмя: {0}\n\t\t\tМаксимальная скорость: {1} \n\t\t\tСкорость: {2}", truck.NameTruck, truck.MaxSpeed, truck.Speed);

            try
            {
                Console.Write("\n\n\t\t\tВведите новую скорость для СпортКар: ");
                sportCar.Speed = int.Parse(Console.ReadLine());

                if (sportCar.Speed > sportCar.MaxSpeed)
                {
                    sportCar.GoodCar = false;
                    throw new SpeedOutMaxSpeed("\n\n\t\t\tСпортКар - сломался!");
                }

                Console.Write("\n\n\t\t\tВведите новую скорость для Трак: ");
                truck.Speed = int.Parse(Console.ReadLine());

                if (truck.Speed > truck.MaxSpeed)
                {
                    truck.GoodCar = false;
                    throw new SpeedOutMaxSpeed("\n\n\t\t\tТрак - сломался!");
                }

                Console.WriteLine("\n\n\n\n\n\tСпортКар \tИмя: {0}\n\t\t\tМаксимальная скорость: {1} \n\t\t\tСкорость: {2}", sportCar.NameSportCar, sportCar.MaxSpeed, sportCar.Speed);
                Console.WriteLine("\n\n\tТрак \t\tИмя: {0}\n\t\t\tМаксимальная скорость: {1} \n\t\t\tСкорость: {2}", truck.NameTruck, truck.MaxSpeed, truck.Speed);
            }

                catch(SpeedOutMaxSpeed exeption)
                { 
                    Console.WriteLine("\n\n\t\tExeption: {0}", exeption.Message);
                }
            
        }
    }
}

