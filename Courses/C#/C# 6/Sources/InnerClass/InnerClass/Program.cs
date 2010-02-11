using System;

namespace InnerClass
{
    class Program
    {
        class A<T>
        {
            public class Inner
            {
            }
        }

        class B<T>
        {
            //вложенный класс имеет собственный список параметров типа
            public class Inner<U>
            {
            }
        }
        static void Main(string[] args)
        {
            //для использования вложенного класса 
            //необходимо указать реальный тип вместо параметра типа внешнего класа
            A<int>.Inner a = new A<int>.Inner();
            Console.WriteLine(a);
            A<double>.Inner a1 = new A<double>.Inner();
            Console.WriteLine(a1);

            //для использования вложенного класса 
            //необходимо указать реальный тип вместо парметра типа вложенного класса
            B<int>.Inner<string> b = new B<int>.Inner<string>();
            Console.WriteLine(b);
        }
    }
}
