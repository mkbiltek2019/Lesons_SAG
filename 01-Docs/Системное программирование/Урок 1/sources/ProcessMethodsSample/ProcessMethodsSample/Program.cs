using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ProcessMethodsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Прмер запуска процесса";
            //Объявляем объект класса Process
            Process proc = new Process();
            //устанавливаем имя файла, который будет запущен в рамках процесса
            proc.StartInfo.FileName = "notepad.exe";
            //запускаем проуцесс
            proc.Start();
            //выводим имя процесса
            Console.WriteLine("Запущен процесс: " + proc.ProcessName);
            //ожидаем ззакрытия процесса
            proc.WaitForExit();
            //выводим код, с которым завершился процесс
            Console.WriteLine("Процесс завершился с кодом: " + proc.ExitCode);
            //выводим имя текущего процесса
            Console.WriteLine("Текущий процесс имеет имя: " +
                        Process.GetCurrentProcess().ProcessName); 

        }
    }
}
