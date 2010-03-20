using System;

namespace ValueAndReferencedTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = x;
            x = x - 5;
            Console.WriteLine("X:\t" + x.ToString());
            //выводит в консоль: X: 5
            Console.WriteLine("Y:\t" + y.ToString());
            //выводит в консоль: Y: 10
        }
    }
}
