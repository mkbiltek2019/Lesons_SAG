using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IfCondition
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX = 10;
            Console.Write("Угадайте число от 1 до {0}...", MAX);
            int userNumber = Convert.ToInt32(Console.ReadLine());
            Random rnd = new Random();
            double PcNumber = rnd.NextDouble() * MAX;
            PcNumber = Math.Round(PcNumber);
            Console.Write("Правильное число {0}, а вы задали {1}...\n",
                                         PcNumber, userNumber);
            if (PcNumber == userNumber) // Число угадано! 
            {
                Console.WriteLine("Поздравляем!");
            }
        }
    }
}
