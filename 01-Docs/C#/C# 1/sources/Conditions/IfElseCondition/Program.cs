using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IfElseCondition
{
    class TestClass
    {
    } ;
    class Program
    {
        static void Main(string[] args)
        {
            int f = 1;
            TestClass my = new TestClass();
            if (f) // Ошибка: попытка перевести int в bool. 
            {
                Console.WriteLine(f);
            }
            if (my) // Ошибка: попытка перевести Test в bool. 
            {
                Console.WriteLine("Это обьект класса Test");
            }
        }
    }
}
