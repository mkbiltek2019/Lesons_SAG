using System;
using System.IO;
using System.Threading;

namespace SampleProject
{
    class Program
    {
        static void Main(string[] args)
        {
// Создание делегата который будет связан с методом шифрования или де шифрования
ParameterizedThreadStart Param = null;
while (true)
{
    // Меню где пользователю предлогается выбрать действие.
    Console.Clear();
    Console.WriteLine("1. Шифровать");
    Console.WriteLine("2. Дешифровать");
    
    ConsoleKeyInfo Select = Console.ReadKey(true);
    Console.Clear();

    if (ConsoleKey.D1 == Select.Key)
    {
        // Если пользователь выбрал шифрование мы связаваем делегат с методом шифрования.
        Param = new ParameterizedThreadStart(Encryption);
        Console.WriteLine("Введите путь к файлу который хотите зашифровать");
    }
    else if(ConsoleKey.D2 == Select.Key)
    {
        // Если пользователь выбрал де шифрование мы связаваем делегат с методом де шифрования.
        Param = new ParameterizedThreadStart(Decryption);
        Console.WriteLine("Введите путь к файлу который хотите расшифровать"); 
    }
    if(ConsoleKey.D1 == Select.Key || ConsoleKey.D2 == Select.Key)
    {
        // Пользователь вводит путь к файлу с которым собирается работать.
        string FilePath = Console.ReadLine();
        
        // Создание потока который будет шифровать / де шифровать.
        Thread thread = new Thread(Param);

        // Старт потока в параметр передается путь к файлу.
        thread.Start((object)FilePath);

        Console.WriteLine("Нажмите символ чтобы выполнить действие");
        do
        {
            // в цикле пользователю предлагаются выбрать действие с потоком.
            Console.WriteLine("[c] Отменить работу потока");
            Console.WriteLine("[p] приостановить или возобновить работу потока");
            ConsoleKeyInfo Selects = Console.ReadKey(true);
            if (Selects.Key == ConsoleKey.C)
            {
                if (thread.ThreadState == ThreadState.Running)
                {
                    // Если поток выполнялся и пользователь выбрал завершение
                    thread.Abort();// Завершаем работу потока
                    Console.WriteLine("Поток остановлен");
                }
            }
            else if (Selects.Key == ConsoleKey.P)
            {
                if (thread.ThreadState == ThreadState.Running)
                {
                    // Если поток выполнялся и пользователь выбрал приостановление
                    thread.Suspend(); // Приостанавливаем поток.
                    Console.WriteLine("Поток приостановлен");
                }
                else if (thread.ThreadState == ThreadState.Suspended) 
                {
                    // если поток остановлен и пользователь выбрал возобновление
                    thread.Resume(); // Возобновляем поток.
                    Console.WriteLine("Поток востановил работу");
                }
                Thread.Sleep(100);
            }

            // Если поток приостановленн или работает, то показать это меню пользователю еще раз.
        } while (thread.ThreadState == ThreadState.Suspended || thread.ThreadState == ThreadState.Running);

        
        Console.ReadKey(true);
        Console.Clear();
    }
}
        }

        // Метод шифрования.
        static void Encryption(object ObjFilePath)
        {
            
            FileStream RFile = null;
            FileStream WFile = null;
            try
            {
                string FilePath = (string)ObjFilePath;
                RFile = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
             
                string NewFile = FilePath + ".cryp";
                WFile = new FileStream(NewFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                Console.WriteLine("Процесс начался");
             
                for (long i = 0; i < RFile.Length; i++)
                { 
                    byte One = (byte)RFile.ReadByte();
                    One = (byte)~One;
                    WFile.WriteByte(One);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Шифрование успешно завершенно");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in Encryption " + ex.Message);
                
            }
            finally
            {
                Console.ResetColor();
                RFile.Close();
                WFile.Close();
                Console.WriteLine("Поток завершил свою работу");
                Console.WriteLine("Нажмите любую клавишу для продолжения");
            }
            
        }

        // Метод де шифрования
        static void Decryption(object ObjFilePath)
        {
            FileStream RFile = null;
            FileStream WFile = null;
            try
            {
                string FilePath = (string)ObjFilePath;
                RFile = new FileStream(FilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
               
                string NewFile = FilePath.Substring(0, FilePath.Length - 5);
                WFile = new FileStream(NewFile, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                Console.WriteLine("Процесс начался");
                for (long i = 0; i < RFile.Length; i++)
                {
                    byte One = (byte)RFile.ReadByte();
                    One = (byte)~One;
                    WFile.WriteByte(One);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Дешифрование успешно завершенно");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error in Decryption " + ex.Message);

            }
            finally
            {
                Console.ResetColor();
                RFile.Close();
                WFile.Close();
                Console.WriteLine("Поток завершил свою работу");
                Console.WriteLine("Нажмите любую клавишу для продолжения");
            }
        }
    }
}
