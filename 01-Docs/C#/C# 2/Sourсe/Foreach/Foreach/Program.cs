using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[,] myArr2 = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[][] myArr3 = new int[3][]{new int[3]{1,2,3}, 
                                    new int[2]{1,2}, 
                                    new int[4]{1,2,3,4}};

            Console.WriteLine("Одномрный массив");
            foreach (int i in myArr1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nДвумерный массив");
            foreach (int i in myArr2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\nРваный массив");
            for (int i = 0; i < myArr3.Length; ++i)
            {
                foreach (int j in myArr3[i])
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
