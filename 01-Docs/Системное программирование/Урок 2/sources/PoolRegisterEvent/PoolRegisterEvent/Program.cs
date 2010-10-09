using System;
using System.Threading;

namespace PoolRegisterEvent
{
    class PoolRegisterEventClass
    {
        static void Main(string[] args)
        {
            AutoResetEvent are = new AutoResetEvent(false);
            RegisteredWaitHandle rwh = ThreadPool.RegisterWaitForSingleObject(are, // Ожидать этот объект AutoResetEvent. 
                                                                                EventOperation, // Выполнить обратный вызов этого метода. 
                                                                                null, // Передать null в качестве параметра EventOperation. 
                                                                                5000, // Ждать освобождения 5 секунд. 
                                                                                false); // Вызывать EventOperation при каждом освобождении. 
            char operation;
            Console.WriteLine("S=Signal, Q=Quit?");
            do
            {
                operation = Char.ToUpper(Console.ReadKey(true).KeyChar);
                if (operation == 'S')
                    are.Set();
            } while (operation != 'Q');

            rwh.Unregister(null);
        }

        private static void EventOperation(Object state, Boolean timedOut)
        {
            if (timedOut)
            {
                Console.WriteLine("Время ожидания истекло...");
            }
            else
            {
                Console.WriteLine("Поток {0} отработал", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}