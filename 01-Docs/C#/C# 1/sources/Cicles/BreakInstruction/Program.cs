using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreakInstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 6 == 0)
                {
                    Console.WriteLine(i);
                }
                if (i == 66)
                {
                    break;
                }
            } 
        }
    }
}
