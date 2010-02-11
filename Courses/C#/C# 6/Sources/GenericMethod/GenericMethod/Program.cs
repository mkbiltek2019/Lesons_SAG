using System;

namespace GenericMethod
{
    class Program
    {
        /// <summary>
        /// Обобщенный метод поиска максимального элемента в массиве
        /// </summary>
        /// <typeparam name="T">тип элементов массива</typeparam>
        /// <param name="a">исходный массив</param>
        /// <returns>найденный максимальный элемент</returns>
        static T MaxElem<T>(T[] a) where T : IComparable
        {
            T m = a[0];
            foreach (T t in a)
            {
                if (t.CompareTo(m) > 0) m = t;
            }
            return m;
        }
        static void Main(string[] args)
        {
            int[] a = new int[] { 2, 6, 8 };
            //реальный тип для параметра типа указывается явно
            Console.WriteLine(MaxElem<int>(a));
            //реальный тип определяется по типу переданного массива
            Console.WriteLine(MaxElem(a));

        }
    }
}
