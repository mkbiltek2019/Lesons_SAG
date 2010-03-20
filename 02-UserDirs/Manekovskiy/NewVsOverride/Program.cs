using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewVsOverride
{
    public interface IPrintable
    {
        void Print();
    }

    public class Human : IPrintable
    {
        public virtual void Print()
        {
            Console.WriteLine("Human");
        }
    }

    public class Employee : Human
    {
        public new void Print()
        {
            Console.WriteLine("Employee");
        }
    }

    public class Teacher : Employee
    {
        public void Print()
        {
            Console.WriteLine("Teacher");
        }
    }

    public abstract class Car
    {
        public static string Speed = "Unknown";
    }

    public class EuropeanCar : Car
    {
        public static string Speed = "km/h";
    }

    public class AmericanCar : Car
    {
        //public new static string Speed = "m/h";
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Teacher teacher = new Teacher();
            //teacher.Print();

            Console.WriteLine(Car.Speed);
            Console.WriteLine(EuropeanCar.Speed);
            Console.WriteLine(AmericanCar.Speed);
        }
    }
}
