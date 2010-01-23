using System;

namespace ReferenceTypesSample2
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
            Point b = new Point();
            b.X = a.X = 10;
            b.X = b.X - 5;
            Console.WriteLine("a.X:\t" + a.X.ToString());
            //выводит в консоль: a.X: 10
            Console.WriteLine("b.X:\t" + b.X.ToString());
            //выводит в консоль: b.X: 5
        }
    }
}
