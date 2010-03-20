using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssignationOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 1;
            int result = 0;
            result = a + b;
            Console.WriteLine(result); //11
            result += b;
            Console.WriteLine(result); //12
            result -= a;
            Console.WriteLine(result); //2
            result *= 6;
            Console.WriteLine(result);//12
            result /= 3;
            Console.WriteLine(result);//4
        }
    }
}
