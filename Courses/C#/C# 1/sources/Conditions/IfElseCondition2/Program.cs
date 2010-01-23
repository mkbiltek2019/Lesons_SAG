using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IfElseCondition2
{
    class TestClass
    {
    } ;
    class Program
    {
        static void Main(string[] args)
        {
            int f = 1;
            TestClass my = new TestClass();
            if (f > 0)
            {
                Console.WriteLine(f);
            }
            if (my != null)
            {
                Console.WriteLine("Это обьект класса Test");
            }
            else
            {
                Console.WriteLine("Test");
            }

        }
    }
}
