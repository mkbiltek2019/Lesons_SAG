using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodOverlode
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 20, c = 30;
            double da = 2.5, db = 4.8;
            Console.WriteLine("{0} + {1} = {2}", a, b, Mathematic.Sum(a, b));
            Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, Mathematic.Sum(a, b, c));
            Console.WriteLine("{0} + {1} = {2}", a, b, Mathematic.Sum(da, db));
        }
    }
}
