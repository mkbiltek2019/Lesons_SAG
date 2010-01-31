using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Class
    {
        private readonly int num = 10;

        public int Num
        {
            get { return num; }
        }
    }
    class Tester
    {
        static void Main(string[] args)
        {
            Class obj1 = new Class();
            Console.WriteLine(obj1.Num);
        }
    }
}
