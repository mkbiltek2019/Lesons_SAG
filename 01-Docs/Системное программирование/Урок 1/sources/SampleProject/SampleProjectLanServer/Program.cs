using System;
using System.Threading;

// Приложение не является сетевым, оно только симуляруетработу сети.

namespace SampleProjectLanServer
{
    class Program
    {

        // Основной метод программы.
        static void Main(string[] args)
        {
            // Создаем и запускаем "слушатель".
            ThreadStart Lis = new ThreadStart(LisenerClient);
            Thread LisenerThread = new Thread(Lis);

            LisenerThread.IsBackground = false;
            LisenerThread.Start();
        }

        // Метот который будет выполнятся в отдельном потоке
        // и будет ждать подключений от пользователей.
        static void LisenerClient()
        {
            int Counter = 0;
            while (true)
            {

                // Нажатием кнопки пользователь, симулирует сетевое подключения пользователя
                // к серверу.
                Console.WriteLine("Нажмите любую клавишу для симуляции подключения пользователя");
                Console.ReadKey(true);

                ParameterizedThreadStart UserDel =
                    new ParameterizedThreadStart(UserThreadFunk);

                // Создание объекта потока (Для каждого клиента)
                Thread UserWorkThread = new Thread(UserDel);

                // Запуск потока.
                UserWorkThread.Start((object)Counter.ToString());
                Counter++;
            }
        }

        // Метот будет выполнятся в отдельном потоке,
        // для каждого подключенного клиента 
        static void UserThreadFunk(object a)
        {
            string UserName = (string)a;
            Console.WriteLine("пользователь\t# "+UserName+" подключился");
            while (true)
            {
                // Ожидание команды пользователя.
                switch (GetUserCommand())
                {
                    case 0:
                        Console.WriteLine("пользователь\t# {0} подписался на новости" , UserName );
                        break;
                    case 1:
                        Console.WriteLine("пользователь\t# {0} начал чат", UserName);
                        break;
                    case 2:
                        Console.WriteLine("пользователь\t# {0} купил продукцию в магазине", UserName);
                        break;
                    case 3:
                        Console.WriteLine("пользователь\t# {0} отправил письмо", UserName);
                        break;
                    case 4:
                        Console.WriteLine("пользователь\t# {0} Отключился", UserName);
                        return; // Завершение потока
                }

            }


        }


        // Метот имитирующий работу пользователя
        static int GetUserCommand()
        {
            Random Rand = new Random();
            while (true)
            {
                Thread.Sleep(100);
                int Gener = Rand.Next(0, 50);
                if (Gener == 0)
                {
                    return 0;
                }
                else if (Gener == 1)
                {
                    return 1;
                }
                else if (Gener == 2)
                {
                    return 2;
                }
                else if (Gener == 3)
                {
                    return 3;
                }
                else if (Gener == 4)
                {
                    return 4;
                }

            }
        }
        
    }
}
