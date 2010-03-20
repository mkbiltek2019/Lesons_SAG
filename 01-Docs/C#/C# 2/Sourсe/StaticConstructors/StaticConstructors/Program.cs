using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank b1 = new Bank(1000000);
            Console.WriteLine("Текущий бонусный процент: " + Bank.GetBonus());
            Console.WriteLine("Ваш депозит на {0:C}, в кассе забрать: {1:C}", 
                10000, b1.GetPercents(10000));
        }
    }
}
