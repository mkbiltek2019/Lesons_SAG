using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Конструктор по умолчанию");
            Car myCar = new Car();
            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }

            Console.WriteLine("\n\nКонструктор с параметрами");
            myCar = new Car("Рубенс Барикелло");
            for (int i = 0; i <= 10; i++)
            {
                myCar.SpeedUp(5);
                myCar.PrintState();
            }


        }
    }
}
