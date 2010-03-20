using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringAndArray
{
    class Program
    {
        static void Main(string[] args)
        {
            myClass menu;
            menu = new myClass();
            bool exit = false;
            do
            {
                switch (menu.ShowMenu())
                {
                    case 0:/*exit*/
                        exit = true;
                        break;
                    case 1:/*Намалювати ялинку*/
                        menu.DrawSpruce();
                        break;
                    case 2:/*Намалювати прямокутник*/
                        menu.DrawRectangle();
                        break;
                    case 3:/*Табличка множення*/
                        menu.DrawMultiplicationtable();
                        break;
                    case 4:/*Перевірка строки на симетричність*/
                        menu.TestString();
                        break;
                    case 5:/*Перевірка числа на симетричність*/
                        menu.TesrInteger();
                        break;
                    case 6:
                        menu.SumArray();
                        break;
                    case 7:
                        menu.SumMatrix();
                        break;
                    case 8:
                        menu.MoveRect();
                        break;
                    case 9:
                        menu.CountNumberStr();
                        break;
                    case 10:
                        menu.CountWord();
                        break;                        
                    case 11:
                        menu.Encryption();
                        break;
                    case 12:
                        menu.RotateString();
                        break;
                    case 13:
                        menu.TrianglePascal();
                        break;
                    case 14:
                        menu.SortSum();
                        break;
                    default:
                        break;
                }

            } while (!exit);


        }
    }
}
