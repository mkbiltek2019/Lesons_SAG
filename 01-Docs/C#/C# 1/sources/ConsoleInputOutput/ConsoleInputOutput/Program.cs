using System;

namespace ConsoleInputOutput
{
    class Program
    {
        static void Main(string[] args)
        {
            //изменяет заголовок окна консоли
            Console.Title = "Пример использования инструментов класса Console";
            //изменяет цвет фона
            Console.BackgroundColor = ConsoleColor.White;
            //изменяет цвет текста
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            //получаем размер самого длинного сообщения в рамках нашей программы
            int length = ("Input Encoding:  " + Console.InputEncoding.ToString()).Length+1;
            //усанавливаем размер окна консоли
            Console.SetWindowSize(length, 8);
            /*усанавливаем размер буфера консоли 
            (размер окна должен быть соответствующим и должен быть установлен до того,
            как мы изменим размер бьуфера)*/
            Console.SetBufferSize(length, 8);
            //выводим информацию о кодировке потока ввода
            Console.WriteLine("Input Encoding:  " + Console.InputEncoding.ToString());
            //выводим информацию о кодировке потока вывода
            Console.WriteLine("Output Encoding: " + Console.OutputEncoding.ToString());
            //устанавливает зеначение цвета фона и текста в значение по умолчанию
            Console.ResetColor();
            //выводим информацию о том, нажат ли NUM LOCK
            Console.WriteLine("Is NUM LOCK turned on: " + Console.NumberLock.ToString());
            //выводим информацию о том, нажат ли CAPS LOCK
            Console.WriteLine("Is CAPS LOCK turned on: " + Console.CapsLock.ToString());
            //выводим пользователю сообщение о том, что программа ожидает ввода некоторой информации
            Console.Write("Enter a simpe message: ");
            //получаем от пользователя текстовое сообщение
            string message = Console.ReadLine();
            //выводим сообщение, введённое пользователем
            Console.WriteLine("Your message is: " + message);
        }
    }
}
