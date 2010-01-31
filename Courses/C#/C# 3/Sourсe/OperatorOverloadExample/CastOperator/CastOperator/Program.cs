using System;

namespace CastOperator
{
    class CPoint
    {
        int x, y;
        public CPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        //может быть потеря точности, преобразование должно быть явным
        public static explicit operator int(CPoint p)
        {
            return (int)Math.Sqrt(p.x * p.x + p.y * p.y);
            //можно и так: return (int)(double)p;    
        }
        //преобразование без потери точности, может быть неявным
        public static implicit operator double(CPoint p)
        {
            return Math.Sqrt(p.x * p.x + p.y * p.y);
        }
        //переданное значение сохраняется в x и y координате,
        //преобразование без потери точности, может быть неявным
        public static implicit operator CPoint(int a)
        {
            return new CPoint(a, a);
        }
        //преобразование c потерей точности, должно быть явным
        public static explicit operator CPoint(double a)
        {
            return new CPoint((int)a, (int)a);
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
            CPoint p = new CPoint(2, 2);
            int a = (int)p; //выполнение явного преобразования CPoint в int
            double d = p;   //выполнение неявного преобразования CPoint в double
            Console.WriteLine("p as int: {0}", a); //2
            Console.WriteLine("p as double: {0:0.0000}", d);   //2.8284
            p = 5; //выполнение неявного преобразования int в CPoint
            Console.WriteLine("p: {0}", p); //x = 5 y = 5
            p = (CPoint)2.5; //выполнение явного преобразования double в CPoint
            Console.WriteLine("p: {0}", p); //x = 2 y = 2
            Console.ReadLine();
        }
    }
}
