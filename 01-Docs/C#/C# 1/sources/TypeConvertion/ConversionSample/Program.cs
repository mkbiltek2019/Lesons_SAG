using System;

namespace ConversionSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //выводим пользователю сообщение о том, 
            //что необходимо ввести целое число в консоль
            Console.Write("Введите целое число: ");
            //получаем строку из консоли в строковую переменную
            string numberString = Console.ReadLine();
            //конвертируем строковое значение в числовое
            int number = Convert.ToInt32(numberString);
            //выводим результат
            Console.WriteLine("Строка была успешно отконвертирована в тип данных int!");
            Console.WriteLine("Число = " + number);
        }
    }
}
