using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhileCicle
{
    class Program
    {
        static void Main(string[] args)
        {
            // Сложение чисел сгенерированых 
            //компьютером в диапазоне от 0 до 20 пока сумма не будет 
            //равна 100, вывести количество чисел
            int counter = 0; //счетчик для чисел
            Random rand = new Random();
            int number; //переменная для хранения числа
            int summ = 0;  //переменная для хранения суммы          
            while (summ <= 100) //пока сумма меньше 100
            {
                number = rand.Next(0, 20); //генерируем число
                summ += number; //добавляем к сумме
                counter++;       //прибавляем счетчик       
            }
            Console.WriteLine(
            "Для суммы было сгенерировано {0} чисел от 0 до 20", counter);              
        }
    }
}
