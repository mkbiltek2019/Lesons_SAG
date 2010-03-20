using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operatorISChecker
{
    public abstract class A {
        public abstract void create();
    }

    public class B : A {
        public override void create()
        {
            System.Console.WriteLine("Class B method create()");
        }
    }
    public class C : B {
        public new void create() {
            System.Console.WriteLine("Class C method create()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            C myC = new C();
            B myB = new B();

            System.Console.WriteLine("C is B = {0}", myC is B);
            System.Console.WriteLine("C is A = {0}", myC is A);

            System.Console.WriteLine("B is C = {0}", myB is C);
        }
    }
}
