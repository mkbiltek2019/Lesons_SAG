using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int Vk1 = 1000;
            int Vk2 = 1100;
            int Vkp = 0;
            Console.Write("Введите процент увеличения вклада в месяц P:");
            string P = Console.ReadLine();
            int p = Convert.ToInt32(P);
            Vkp = (1000 * p) / 100;
            Console.WriteLine("Процент равен суме=" + Vkp);
            for (int i = 0; i <= 100; )
            {
                int Skp = Vkp * i + Vk1;
                i = i + 1;
                if (Skp > Vk2)
                {
                    Console.WriteLine("Сумма на счету вырастет выше 1100 за:" + i + " месяця и будет равна " + Skp);
                    break;
                }
            }
        }
    }
}
