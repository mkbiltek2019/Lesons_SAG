using System;
using NS;
using NS1;
namespace M
{
    public class ClassM
    {
        public static void Main()
        {
            NS.Class objA = new NS.Class();
            Console.WriteLine("objA = {0}", objA.a);
            objA.Print();

            NS1.Class objB = new NS1.Class();
            Console.WriteLine("objB = {0}", objB.b);
            objB.Print();

        }
    }
}
