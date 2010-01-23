using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TernaryOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            int myInt = 0;
            int anotherInt = myInt != 0 ? 1 : 1234;
            Console.WriteLine(anotherInt.ToString());
        }
    }
}
