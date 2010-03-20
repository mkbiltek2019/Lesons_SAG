using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MethodOverlode
{
    class Mathematic
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }
        public static int Sum(int a, int b, int c)
        {
            return a + b + c;
        }
        public static double Sum(double a, double b)
        {
            return a + b;
        }
    }
}
