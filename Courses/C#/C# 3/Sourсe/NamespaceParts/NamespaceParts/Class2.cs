using System;
using A;
namespace A
{
    class ClassB
    {
        public void Print()
        {

            Console.WriteLine("Printing from A.ClassB");
        }
    }
}
namespace B
{
    public class Class
    {
        public static void Main()
        {
            ClassA a = new ClassA();
            a.Print();
            ClassB b = new ClassB();
            b.Print();
            ClassC c = new ClassC();
            c.Print();
        }
    }
}
namespace A
{
    class ClassC
    {
        public void Print()
        {
            Console.WriteLine("Printing from A.ClassC");
        }
    }
}
