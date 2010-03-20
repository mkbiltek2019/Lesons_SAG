using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoWhileCicle
{
    class Program
    {
        static void Main(string[] args)
        {
            // посчитать сумму всех цифр любого числа
            int sum = 0; //переменная для суммы
            int N = 0; //любое число
            Console.WriteLine("Введите любое целое число:");
            N = Convert.ToInt32(Console.ReadLine());
            int a = N; //Запоминаем число
            do
            {
                sum = sum + N % 10; //находим последнюю цифру и суммируем её                
                N = (N - N % 10) / 10; //отсекаем последнюю цифру от числа
            } while (N > 0);
            //если N больше нуля, вернуться и повторить операторы тела цикла
            Console.WriteLine("Сумма всех цифр числа  {0} = {1}", a, sum);            
        }
    }
}
