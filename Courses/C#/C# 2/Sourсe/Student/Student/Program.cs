using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student();
            st1.ShowName();
            Student.ShowAcademy();
            Console.WriteLine("Оценка: {0}", st1.GetMark());
        }
    }
}
