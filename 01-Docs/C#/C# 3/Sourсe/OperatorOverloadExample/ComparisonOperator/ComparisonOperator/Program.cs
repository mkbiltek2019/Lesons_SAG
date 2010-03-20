using System;
using System.Collections.Generic;
using System.Text;

namespace ComparisonOperator
{
    using System;
    class CPoint
    {
        int x, y;
        public CPoint(int x, int y)
        {
            this.x = x; this.y = y;
        }
        //Перегрузка метода Equals
        public override bool Equals(object obj)
        {
            //если obj == null, значит он != объекту, от имени которого вызывается этот метод
            if (obj == null) return false;
            CPoint p = obj as CPoint;
            //переданный объект не является ссылкой на CPoint
            if (p == null) return false;
            //проверяется равенство содержимого
            return ((x == p.x) && (y == p.y));
        }

        //При перегрузке Equals надо также перегрузить GetHashCode()
        public override int GetHashCode()
        {
            return x ^ y;//использование XOR для получения хеш кода
        }

        public static bool operator ==(CPoint p1, CPoint p2)
        {
            //проверка, что переменные ссылаются на один и тот же адрес
            //сравнение p1 == p2 приведет к бесконечной рекурсии
            if (ReferenceEquals(p1, p2)) return true;
            //приведение к object необходимо, 
            //т.к. сравнение p1 == null приведет к бесконечной рекурсии
            if ((object)p1 == null) return false;
            return p1.Equals(p2); 
        }

        public static bool operator !=(CPoint p1, CPoint p2)
        {
            return (!(p1 == p2));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CPoint cp = new CPoint(0, 0);
            CPoint cp1 = new CPoint(0, 0);
            CPoint cp2 = new CPoint(1, 1);
            Console.WriteLine("cp == cp1: {0}", cp == cp1); //true
            Console.WriteLine("cp == cp1: {0}", cp == cp2); //false
            Console.ReadLine();
        }
    }
}
