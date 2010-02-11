using System;
using System.Collections.Generic;

namespace GenericInterface
{
    /// <summary>
    /// Обобщенный интерфейс с методам вычисления суммы
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ICalc<T>
    {
        T Sum(T b);
    }
    class Program
    {

        /// <summary>
        /// Необобщенный класс, реализующий интерфейс ICalc
        /// </summary>
        class calcInt : ICalc<calcInt> //при наследовании указывается реальный тип данных
        {
            int a = 0;
            public calcInt(int a)
            {
                this.a = a;
            }
            #region ICalc<int> Members
            //при реализации методов вместо обобщенного типа используется тип calcInt
            public calcInt Sum(calcInt b)
            {
                return new calcInt(this.a + b.a);
            }
            #endregion
            public override string ToString()
            {
                return a.ToString();
            }
        }

        /// <summary>
        /// Обобщенный класс, который содержит в себе коллекцию данных обобщеного типа
        /// и имеет метод вычисления суммы
        /// Для вычисления суммы задается оганичение: 
        /// параметр типа должен реализовать интерфейс ICalc<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class MyArray<T> where T : ICalc<T>
        {
            //коллекция данных обобщенного типа
            List<T> li = new List<T>();
            //метод добавления данных в коллекцию
            public void Add(T t) { li.Add(t); }
            //метод вычисления суммы
            public T Sum()
            {
                if (li.Count == 0) return default(T);
                T res = li[0];
                //для суммирования используется метод интерфейса ICalc<T>
                for (int i = 1; i < li.Count; i++) res = res.Sum(li[i]);
                return res;
            }
        }

        static void Main(string[] args)
        {
            MyArray<calcInt> a = new MyArray<calcInt>();
            a.Add(new calcInt(10));
            a.Add(new calcInt(20));
            Console.WriteLine(a.Sum());
        }
    }
}
