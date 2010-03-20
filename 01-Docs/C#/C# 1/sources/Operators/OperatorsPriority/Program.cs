using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperatorsPriority
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10; int b = 1;
            int result = a + b * 2;
            Console.WriteLine(result); //12
            result = (a + b) * 2;
            Console.WriteLine(result); //22
            result = a + b - 4 * 2;
            Console.WriteLine(result); //3
            result = (a + (b - 4)) * 2;
            Console.WriteLine(result); //14
        }
    }
}
