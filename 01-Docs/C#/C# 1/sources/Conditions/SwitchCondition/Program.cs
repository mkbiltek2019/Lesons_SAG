using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwitchCondition
{
    class Program
    {
        static void Main(string[] args)
        {
            int Num = 0, Price = 0;
            switch (Num)
            {
                //Если количество товара до 4 штук, то цена 25 Коп за 1 единицу товара.
                case 1:
                case 2:
                case 3:
                case 4:
                    Price = 25;
                    break;
                //Если количество товара от 5 до 8 штук, то цена 23 Коп за 1 единицу товара.
                case 5:
                case 6:
                case 7:
                case 8:
                    Price = 23;
                    break;
                // Иначе устанавливаем цену в ноль.
                default:
                    Price = 0;
                    break;
            }            
        }
    }
}
