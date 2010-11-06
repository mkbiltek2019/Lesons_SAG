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

        private static Logger instance = null;
        /*
         * Свойство, предоставляющие доступ к единственному экземпляру.
         * Демонстрирует пример позднего связывания одиночки.
         */
        public static Logger Instance
        {
            get
            {
                /* 
                 * Критическая секция.
                 * Исключает возможность одновременного создания 
                 * нескольких экземпляров Logger 
                 * из параллельных потоков.
                 */
                lock (sync)
                {
                    if (instance == null)
                    {
                        instance = new Logger();
                    }
                    return instance;
                }
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
         * Метод вывода собщения в журнал событий.
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