using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cycleWhile = 0;
            int cycleFor = 0;
           
            Console.Write("Введите цифру А(min):");
            int min = Convert.ToInt32(Console.ReadLine());
           
            Console.Write("Введите цифру max(max):");
            int max = Convert.ToInt32(Console.ReadLine());
           
                begin:
            for (int iCounter = 2; iCounter <= min; iCounter++)
            {
                Console.Write(" {0}" ,min);
                cycleWhile = min - iCounter;
                if (min > max)
                break;
            }
            while (cycleWhile > 0) ;
            
            for (cycleFor = min; cycleFor <= max; )
            {
                Console.Write(" {0}" ,min);
                Console.WriteLine("\n");
                min = cycleFor + 1;
                goto begin;
            }
        }
    }
}
