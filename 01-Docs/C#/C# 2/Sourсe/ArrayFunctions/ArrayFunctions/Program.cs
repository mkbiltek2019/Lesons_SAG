using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            PrintArr("Массив myArr1", myArr1);
            int[] tempArr = (int[])myArr1.Clone();
            Array.Reverse(myArr1, 3, 4);
            PrintArr("Массив myArr1 после реверсирования", myArr1);
            myArr1 = tempArr;
            PrintArr("Массив myArr1 после восстановления", myArr1);

            int[] myArr2 = new int[20];
            PrintArr("Массив myArr2 до копирования", myArr2);
            myArr1.CopyTo(myArr2, 5);
            PrintArr("Массив myArr2 после копирования", myArr2);
            Array.Clear(myArr2, 0, myArr2.GetLength(0));
            PrintArr("Массив myArr2 после чистки: ", myArr2);
            Array.Resize(ref myArr2, 10);
            PrintArr("Массив myArr2 после изменения размера: ", myArr2);
            myArr2 = new[] { 1, 5, 3, 2, 8, 9, 6, 10, 7, 4 };
            PrintArr("Несортированый массив myArr2: ", myArr2);
            Array.Sort(myArr2);
            PrintArr("Массив myArr2 после сортировки: ", myArr2);
            Console.WriteLine("Число 5 находится в массиве на " + Array.BinarySearch(myArr2, 5) + " позиции");
            Console.WriteLine("Максимальный элемент в массиве myArr2: " +
            myArr2.Max());
            Console.WriteLine("Минимальный элемент в массиве myArr2: " +
            myArr2.Min());
            Console.WriteLine("Среднее арифмтическое элементов myArr2: " +
            myArr2.Average());

            int[,] myArr3 = { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine("Количество измерений массива myArr3: " + myArr3.Rank);
        }

        static void PrintArr(string text, int[] arr)
        {
            Console.Write(text + ": ");
            for (int i = 0; i < arr.Length; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }
}
