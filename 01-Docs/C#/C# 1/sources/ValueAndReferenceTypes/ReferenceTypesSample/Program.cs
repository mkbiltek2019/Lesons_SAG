using System;

namespace ReferenceTypesSample
{
    class Program
    {
        class Point
        {
            public int X;
            public int Y;
        }
        static void Main(string[] args)
        {
            Point a = new Point();
            a.X = 10;
            Point b = a;
            b.X = b.X - 5;
            Console.WriteLine("a.X:\t" + a.X.ToString());
            //выводит в консоль: a.X: 5
            Console.WriteLine("b.X:\t" + b.X.ToString());
            //выводит в консоль: b.X: 5
        }
    }
}
