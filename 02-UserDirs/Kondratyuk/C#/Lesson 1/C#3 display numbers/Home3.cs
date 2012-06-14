using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            int h = 0;
            int x = 0;
            Console.Write("Введите цыфру А(min):");
            string A = Console.ReadLine();
            int a = Convert.ToInt32(A);
            Console.Write("Введите цыфру B(max):");
            string B = Console.ReadLine();
            int b = Convert.ToInt32(B);
            begin:   
            for (int i=2;i<=a;i++)
                {
                    Console.Write(" "+a);
                    h = a - i;
                    if (a > b)
                        break;
                }
                while (h > 0);
            for (x=a; x<b;)
            {
                Console.Write(" "+a);
                Console.WriteLine("\n");
                a = x + 1;
                goto begin;   
            }
                
        }
    }
}

