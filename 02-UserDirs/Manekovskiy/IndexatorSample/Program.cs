using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndexatorSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassWithIndexators classWithIndexator = new ClassWithIndexators();
            for (int i = 0; i < classWithIndexator.Length; i++)
            {
                Console.WriteLine(classWithIndexator[i]);
            }

            Console.WriteLine();
            Console.WriteLine("classWithIndexator[1, 2] = {0}", classWithIndexator[1, 2]);
            Console.WriteLine("classWithIndexator[\"first\", \"2\"] = {0}", classWithIndexator["first", "2"]);
            Console.ReadKey();
        }
    }
}
