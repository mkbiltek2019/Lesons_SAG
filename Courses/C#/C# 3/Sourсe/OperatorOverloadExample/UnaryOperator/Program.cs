using System;

namespace UnaryOperator
{
    //класс точки на плоскости – пример для перегрузки операторорв
   class CPoint
    {
        int x, y;
        public CPoint(int x, int y)
        {
            this.x = x; this.y = y;
        }

        //перегрузка инкремента 
        public static CPoint operator ++(CPoint s)
        {
            s.x++; s.y++; return s;
        }
        //перегрузка декремента 
        public static CPoint operator --(CPoint s)
        {
            s.x--; s.y--; return s;
        }
        //перегрузка оператора - 
        public static CPoint operator -(CPoint s)
        {
            CPoint p = new CPoint(s.x, s.y);
            p.x = -p.x; p.y = -p.y; return p;
        }

        public override string ToString()
        {
            return string.Format("X = {0} Y = {1}", x, y);
        }
    }

    class Test
    {
        static void Main()
        {
            CPoint p = new CPoint(10, 10);
            //префиксная и постфиксная формы выполняются одинаково
            Console.WriteLine(++p); //x=11, y=11
            CPoint p1 = new CPoint(10, 10);
            Console.WriteLine(p1++); //x=11, y=11
            Console.WriteLine(--p); //x=10, y=10
            Console.WriteLine(-p); //x=-10, y=-10
            //после выполнения оператора - состояние исходного объекта не изменилось
            Console.WriteLine(p); //x=10, y=10
            Console.ReadLine();
        }
    }
}

