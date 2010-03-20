using System;

namespace A
{
    public class Incrementer
    {
        private int count;

        public Incrementer(int count)
        {
            this.count = count;
        }
        public int MultyIncrement()
        {
            for (int i = 0; i < 5; i++)
                count++;
            return count;
        }
    }

}
namespace B
{
    public class Incrementer
    {
        private int var;

        public Incrementer(int var)
        {
            this.var = var;
        }
        public int MultyIncrement()
        {
            for (int i = 0; i < 5; i++)
                var += 10;
            return var;
        }
    }
    class Tester
    {
        public static void Main()
        {
            Incrementer obj1 = new Incrementer(10);
            Console.WriteLine(obj1.MultyIncrement());
            Incrementer obj2 = new Incrementer(5);
            Console.WriteLine(obj2.MultyIncrement());
        }
    }
}
