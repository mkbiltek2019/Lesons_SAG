using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeachCicle
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Демонстрация цикла foreach. Вычисление суммы,
            /// максимального и минимального элементов
            /// трехмерного массива, заполненного случайными числами.
            int[] arr3d = new int[10];
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                arr3d[i] = rand.Next(100);
            }
            long sum = 0;
            int min = arr3d[0], max = arr3d[0];
            foreach (int item in arr3d)
            {
                sum += item;
                if (item > max)
                    max = item;
                else if (item < min)
                    min = item;
            }
            Console.WriteLine("summa = {0}, minimum = {1}, maximum = {2}", sum, min, max);
        }
    }
}
