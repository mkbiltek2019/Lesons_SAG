using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logger
{

    /*
     * Класс журнала событий программы.
     * Предназначение - запись событий в специальный текстовый файл.
     * В программе может существовать только в одном экземпляре.
     */
    public class Logger
    {
        // Объект для синхронизации
        private static object sync = new object();

        /* 
         * Единственный экземпляр класса.
         * Создается при инициализации класса.
	* Демонстрирует пример раннего связывания одиночки.		 
         */
        private readonly static Logger instance = new Logger();
        /*
         * Свойство, предоставляющие доступ к еднственному экземпляру.         
         */
        public static Logger Instance
        {
            get
            {
                return instance;
            }
        }

        /*
         * Защищенный конструктор.
         * Его вызов не возможен из внешнего кода.
         * Следовательно только сам класс Logger
         * может создавать собственные экземпляры.
         */
        protected Logger()
        {          
        }

        /*
         * Метод вывода сообщения в журнал событий.
         */
        public void PutMessage(string message)
        {
            /*
             * Критическая секция, 
             * исключающая возможность одновременной записи 
             * в файл журнала несколькими параллельными потоками.
             */
            lock (sync)
            {
                using (StreamWriter writer = 
                    new StreamWriter(
                        new FileStream("log.txt", FileMode.Append, FileAccess.Write)))
                {
                    writer.WriteLine("{0}: {1}", DateTime.Now, message);
                }
            }
        }
    }
}