using System;

namespace TypeConvertion
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            /*
            тип double не может быть неявно рпиведён к типу float,
            поскольку тип double более точный, то процедура приведения типа
            происходит с протерейй информации,
            поэтому необходимо указывать суфикс F 
            после инициализирующего значения
            */
            float y = 6.5F;
            /*
            значение переменной x (имеющей тип int) 
            неявно приводится к более точному типу float
            */
            float b = y + x;
        }
    }
}
