using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student
{
    class Student
    {
        public int studentID;
        public string firstName = "Петя";
        public string lastName;
        public string group;

        private static string academyName = "Компьютерная академия \"ШАГ\"";

        public void ShowName()
        {
            Console.WriteLine(firstName);
        }

        public static void ShowAcademy()
        {
            Console.WriteLine(academyName);
        }

        public int GetMark()
        {
            return new Random().Next(1, 12);
        }
    }
}
