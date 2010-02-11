using System;

namespace GeneicClass
{
    /// <summary>
    /// Обобщенный класс точки
    /// </summary>
    /// <typeparam name="T">
    /// координаты точки могут быть любого типа
    /// </typeparam>
    public class Point2D<T>  where T: struct
    {
        private class P
        {
            T p;
        }
        //параметр типа используется для задания типа переменных класса 
        T x;
        T y;
        //параметр типа используется для задания типа свойста
        public T X
        {
            get { return x; }
            set { x = value; }
        }
        public T Y
        {
            get { return y; }
            set { y = value; }
        }
        //параметр типа используется для задания типов параметров метода
        public Point2D(T x, T y)
        {
            this.x = x; this.y = y;
        }
        public Point2D()
        {
            this.x = default(T); this.y = default(T);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            //тестирование обобщенного класса - точки в 2D
            Point2D<int> p1 = new Point2D<int>(10, 20);
            Console.WriteLine("x = {0} y = {1}", p1.X, p1.Y);
            Point2D<double> p2 = new Point2D<double>(10.5, 20.5);
            Console.WriteLine("x = {0} y = {1}", p2.X, p2.Y);
            Console.WriteLine(typeof(Point2D<int>).ToString());
            Console.WriteLine(typeof(Point2D<double>).ToString());
        }
    }
}
