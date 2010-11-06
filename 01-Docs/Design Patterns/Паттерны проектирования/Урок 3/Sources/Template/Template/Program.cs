using System;
namespace Template
{

    class MainApp
    {

        static void Main()
        {

            AbstractClass aA = new ConcreteClassA();

            aA.TemplateMethod();

            AbstractClass aB = new ConcreteClassB();

            aB.TemplateMethod();

            Console.ReadLine();

        }

    }

    // 'AbstractClass' абстрактный класс

    abstract class AbstractClass
    {

        public abstract void PrimitiveOperation1();

        public abstract void PrimitiveOperation2();



        //  "Template method"

        public void TemplateMethod()
        {

            PrimitiveOperation1();

            PrimitiveOperation2();

            Console.WriteLine("");

        }

    }

    // 'ConcreteClassA' класс

    class ConcreteClassA : AbstractClass
    {

        public override void PrimitiveOperation1()
        {

            Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");

        }

        public override void PrimitiveOperation2()
        {

            Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");

        }

    }


    // 'ConcreteClassB' класс

    class ConcreteClassB : AbstractClass
    {

        public override void PrimitiveOperation1()
        {

            Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");

        }

        public override void PrimitiveOperation2()
        {

            Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");

        }

    }

}
