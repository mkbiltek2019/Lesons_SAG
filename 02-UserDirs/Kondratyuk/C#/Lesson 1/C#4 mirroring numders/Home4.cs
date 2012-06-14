using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            int obrt = 0;
            int N=0;
            Console.Write("Введите целое число N(>0):");
            N = Convert.ToInt32(Console.ReadLine());
            int a = N;
            Console.WriteLine("В обратном порядке число имеет вид:");
            do
            {
                obrt = N % 10;
                Console.Write(obrt);
                N = (N - N % (-10))/10;
            }
            while (N > 0);
            Console.WriteLine();
        }
    }
}
