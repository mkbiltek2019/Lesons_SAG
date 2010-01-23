using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticConstructors
{
    class Bank
    {
        private double currBalance;
        private static double bonus;

        public Bank(double balance)
        {
            currBalance = balance;
        }
        static Bank()
        {
            bonus = 1.04;
        }
        public static void SetBonus(double newRate)
        {
            bonus = newRate;
        }
        public static double GetBonus()
        {
            return bonus;
        }
        public double GetPercents(double summa)
        {
            if ((currBalance - summa) > 0)
            {
                double percent = summa * bonus;
                currBalance -= percent;
                return percent;
            }
            return -1;
        }
    }
}
