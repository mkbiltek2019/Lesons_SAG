using System;

namespace ExplicitCponvertion
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 5.7;
            double y = 6.4;
            /*выполняется явное приведение значения переменной,
            имеющей тип данных double, к типу int*/
            int A = (int)x;
            /*выполняется явное приведение результата выражения,
            имеющего тип данных double, к типу int*/
            int B = (int)(x + y);
        }
    }
}
