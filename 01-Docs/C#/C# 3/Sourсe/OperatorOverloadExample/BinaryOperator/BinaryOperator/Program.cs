using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryOperator
{
    class CVector
    {
        public int x;
        public int y;
        public CVector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return string.Format("Vector: X = {0} Y = {1}", x, y);
        }
    }
    class CPoint
    {
        private int x;
        private int y;

        public CPoint(int x, int y)
        {
            this.x = x; this.y = y;
        }

        //перегрузка бинарного оператора +
        public static CPoint operator +(CPoint p, CVector v)
        {
            return new CPoint(p.x + v.x, p.y + v.y);
        }

        //перегрузка бинарного оператора *
        public static CPoint operator *(CPoint p, int a)
        {
            return new CPoint(p.x * a, p.y * a);
        }

        
        public static CPoint operator *(int a, CPoint p)
        {
            return p * a;
        }

        //перегрузка бинарного оператора -
        public static CVector operator -(CPoint p1, CPoint p2)
        {
            return new CVector(p1.x - p2.x, p1.y - p2.y);
        }

        public override string ToString()
        {
            return string.Format("Point: X = {0} Y = {1}", x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CPoint p1 = new CPoint(10,10);
            CPoint p2 = new CPoint(12, 20);
            CVector v = new CVector(10,20);
            Console.WriteLine("Точка p1: {0}",p1);
            Console.WriteLine("Сдвиг: {0}", p1 + v);
            Console.WriteLine("Масштабирование: {0}", p1 * 10);
            Console.WriteLine("Точка p2: {0}",p2);
            Console.WriteLine("Расстояние: {0}",p2 - p1);
            Console.WriteLine("Сдвиг: {0}", p1 + v);
            Console.WriteLine(10*p1);
            Console.ReadLine();
        }
    }
}
