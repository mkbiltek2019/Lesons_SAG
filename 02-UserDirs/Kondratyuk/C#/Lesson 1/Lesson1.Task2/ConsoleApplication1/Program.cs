using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialContribution = 1000;
            int neededContribution = 1100;

            Console.Write("Введите процент увеличения вклада в месяц P:");           
            int P = Convert.ToInt32(Console.ReadLine());

            int percentContribution = (1000 * P) / 100;
            Console.WriteLine("Процент равен суме = {0}", percentContribution);

            for (int monthCount = 0; monthCount <= 100; )
            {
            int finalContribution = percentContribution * monthCount + initialContribution;
            monthCount = monthCount + 1;

            if (finalContribution >  neededContribution)
            {
            Console.WriteLine("Сумма на счету вырастет выше 1100 за: {0} месяца(ов) и будет равна: {1} " , monthCount, finalContribution);
            break;
            }
            }
        }
    }
}
