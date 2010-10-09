using System;

namespace ControlMemory
{
    class DemoNew
    {
        int max;
        String[] AnArray;
        public DemoNew()
        {
            max = 10;
            AnArray = new String[max];
        }
        public DemoNew(int max)
        {
            this.max = max;
            AnArray = new String[max];
        }
        public String this[int i]
        {
            get
            {
                if (i < 0 || i >= max) return null;
                else return AnArray[i];
            }
            set 
            {
                if (i >= 0 && i < max) AnArray[i] = value;
            }
        }
        public int Count
        {
            get { return max; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // создание объекта
            DemoNew arr = new DemoNew();
            Console.WriteLine("Введите элементы объекта arr ({0})",arr.Count);
            for (int i = 0; i < arr.Count; i++)
            {
                Console.Write("{0}: ",i);
                arr[i] = Console.ReadLine();
            }
            int num;
            do {
                Console.WriteLine("Введите номер элемента (от 0 до {0}):",arr.Count - 1);
                num = Convert.ToInt16(Console.ReadLine());
            } while (num < 0 || num >= arr.Count);
            Console.WriteLine(arr[num]);
            // создание массива объекта
            DemoNew[] arrs = new DemoNew[10];
            Random K = new Random();
            for (int i = 0; i < 10; i++)
                arrs[i] = new DemoNew(K.Next(10,20));
            foreach (DemoNew d in arrs)
                Console.Write("{0}\t", d.Count);
            // потеря ссылок
            arr = arrs[3];
            // дальнейшая работа
        }
    }
}
