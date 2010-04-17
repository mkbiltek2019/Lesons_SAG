using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplicationWithEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("AA2233F");
            Car carNumber2 = new Car("BF5533A");
            Policeman policeman = new Policeman(90);

            car.CurrentSpeedChanged += CurrentSpeedChangedEventHandler;
            carNumber2.CurrentSpeedChanged += CurrentSpeedChangedEventHandler;

            car.CurrentSpeedChanged += policeman.CheckCurrentSpeed;
            carNumber2.CurrentSpeedChanged += policeman.CheckCurrentSpeed;

            for (int i = 0; i < 17; i++)
            {
                car.SpeedUp(i);
                carNumber2.SpeedUp(1);
            }
            Console.WriteLine("Before sleep");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("After sleep");
        }

        public static void CurrentSpeedChangedEventHandler(Car car, int speed)
        {
            Console.WriteLine("Speed of {0} car is {1}", car.Number, speed);
        }
    }

    public class Policeman
    {
        private int maximumAllowedSpeed;

        public Policeman(int maximumAllowedSpeed)
        {
            this.maximumAllowedSpeed = maximumAllowedSpeed;
        }

        public void CheckCurrentSpeed(Car sender, int currentSpeed)
        {
            if (currentSpeed > maximumAllowedSpeed)
            {
                Console.WriteLine(
                    "Sergeant Petrento: Your car with number \"{0}\" exceeded the maximum allowed speed({1}).",
                    sender.Number, currentSpeed);
            }
        }
    }

    public delegate void SpeedChangedHandler(Car sender, int currentSpeed);

    public class Car
    {
        private int speed;

        public event SpeedChangedHandler CurrentSpeedChanged;

        public string Number
        {
            get; set;
        }

        public Car(string number)
        {
            speed = 0;
            Number = number;
        }

        public void SpeedUp(int speedChange)
        {
            speed += speedChange;
            if(CurrentSpeedChanged != null)
                CurrentSpeedChanged.Invoke(this, speed);
        }
    }
}
