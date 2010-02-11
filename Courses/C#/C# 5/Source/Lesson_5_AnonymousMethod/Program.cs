using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_5_AnonymousMethod
{
    class Program
    {
        delegate String TestAnonymousDelegate(String str);

        static void Main(string[] args)
        {
            String strMiddle = ", сердняя часть,";

            TestAnonymousDelegate anonymousDelegate = delegate(String parameter)
            {
                parameter += strMiddle;
                parameter += " а эта часть строки добавлена в конец.\n";
                return parameter;
            };

            Console.WriteLine(anonymousDelegate("Начало строки"));
        }
    }
}
