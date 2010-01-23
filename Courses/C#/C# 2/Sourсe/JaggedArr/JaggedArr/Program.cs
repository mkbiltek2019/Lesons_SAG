using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JaggedArr
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 5;
            // Объявление вложеного массива
            int[][] myArr = new int[size][];
            for (int i = 0; i < size; ++i)
            {
                // Создание внутренних массивов
                myArr[i] = new int[i + 1];
                for (int j = 0; j < i + 1; ++j)
                {
                    // Заполнение внутренних массивов
                    myArr[i][j] = j + 1;
                    // Вывод на экран элементов
                    Console.Write(myArr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
