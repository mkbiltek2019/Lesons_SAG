using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Man
{
    class Print
    {
        static private int tableStudentWidth = 85;
        static public void PrintInfo(Man man, string option)
        {
            switch (option)
            {
                case "STUDENT":
                    Print.PrintStudent(man);
                    Print.Wait();
                    break;
                case "TEACHER":
                    Print.PrintTeacher(man);
                    Print.Wait();
                    break;
                case "ACCOUNTANT":
                    Print.PrintAccountant(man);
                    Print.Wait();
                    break;
                default:
                    Console.WriteLine("Failed option!!!");
                    break;
            }
            Console.Clear();
        }
        static private void PrintStr(params string[] str)
        {

            int countSpace = 0;
            Print.PrintDash(tableStudentWidth);
            Console.Write("|");
            for (int i = 0; i < str.Length; i++)
            {
                string strBegin = string.Empty;
                string strEnd = string.Empty;
                countSpace = (20 - str[i].Length) / 2;
                for (int j = 0; j < countSpace; j++)
                {
                    strBegin = strBegin + " ";
                    strEnd = strEnd + " ";
                }
                if ((20 - str[i].Length) % 2 != 0)
                    strEnd = strEnd + " ";
                strEnd = strEnd + "|";
                Console.Write("{0}{1}{2}", strBegin, str[i], strEnd);
            }
            Console.WriteLine();
        }
        //=============================================================================
        static void PrintDash(int witdthTable)
        {
            for (int i = 0; i < witdthTable; i++)
            {
                Console.Write("-");
            }
            Console.Write("\n");
        }
        static void PrintStudent(Man man)
        {
            Print.PrintDash(tableStudentWidth);
            string titleTable = ("|       Name:        |" +
                          "       LastName     |" +
                          "     AverageBall    |" +
                          "      YearBirth     |" +
                           "\n");
            Console.Write(titleTable);
            foreach (var list in man.ListStudent)
                Print.PrintStr(list.Name, list.LastName, list.AverageBall, list.YearBirth);
            Print.PrintDash(tableStudentWidth);
            
        }
        static void PrintTeacher(Man man)
        {
            Print.PrintDash(tableStudentWidth);
            string titleTable = ("|       Name:        |" +
                          "       LastName     |" +
                          "       Salary       |" +
                          "      Name Shool    |" +
                           "\n");
            Console.Write(titleTable);
            foreach (var teacher in man.ListTeacher)
                Print.PrintStr(teacher.Name, teacher.LastName, teacher.Salary, teacher.NameShool);
            Print.PrintDash(tableStudentWidth);
        }
        static void PrintAccountant(Man man)
        {
            Print.PrintDash(tableStudentWidth);
            string titleTable = ("|       Name:        |" +
                          "       LastName     |" +
                          "       Salary       |" +
                          "      Name Shool    |" +
                           "\n");
            Console.Write(titleTable);
            foreach (var list in man.ListAccountant)
                Print.PrintStr(list.Name, list.LastName, list.Salary, list.NameShool);
            Print.PrintDash(tableStudentWidth);
        }
        public static void Proces(string operaionStr)
        {
            string str = string.Empty;
            for (int i = 0; i < Console.WindowWidth - 2; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                int k = 0;
                do
                {
                    k++;
                } while (k < 1000000);
                str = str + "█";
                Console.Clear();

                Console.Write("\n{0}...\n{1}\n{2}\n",operaionStr, str, str);


            }
            Print.Wait();
        }
        public static void Wait()
        {
            Console.ResetColor();
            Console.Write("\nPress any key...");
            Console.ReadKey();
            Console.Clear();

        }
        public static void PrintAll(Man man)
        {
            Print.PrintStudent(man);
            Print.PrintTeacher(man);
            Print.PrintAccountant(man);
            Print.Wait();
        }
    }
}
