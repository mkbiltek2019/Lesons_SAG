using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContinueInstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "один", "д", "три", "один", "тр", "од", "сем", "вос", "дев", "дес" };
            int counter = 1;
            int index = -1;
            Console.WriteLine("Обработка массива...");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == j) continue;
                    if (i == index) i++;
                    if (words[i] == words[j])
                    {
                        counter++;
                        index = j;
                    }
                }
                if (counter > 1)
                    Console.WriteLine("'{0}' встречается в массиве {1} раза", words[i], counter);
                else
                    Console.WriteLine("'{0}' в массиве встречается только 1 раз", words[i]);
                counter = 1;
            } 
        }
    }
}
