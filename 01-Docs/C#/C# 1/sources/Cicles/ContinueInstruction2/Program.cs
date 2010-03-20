using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContinueInstruction2
{
    class Program
    {
        static void Main(string[] args)
        {
            double sr_zarplata=0;	// средняя заработная плата
            double zarplata=0; // текущая заработная плата 
            int kol=0; // количество введенных данных для подсчета средней зарплаты
            do
            {
                Console.WriteLine("Введите зарплату \n для окончания введите значение -1) :\n");
                zarplata=Convert.ToDouble(Console.ReadLine());
                if(zarplata < 0)
                    break;
                if(zarplata < 500)
                    continue;
                else
                {
                    sr_zarplata+=zarplata;
                    kol++;
                } 
            }while   (1==1);  
            sr_zarplata = sr_zarplata/kol;
            Console.WriteLine("Средняя зарплата = {0}", sr_zarplata);
        }
    }
}
