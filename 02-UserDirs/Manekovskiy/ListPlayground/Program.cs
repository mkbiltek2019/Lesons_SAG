using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListPlayground
{
    class Foo { }

    class Bar : Foo { }

    class Program
    {
        static void Main(string[] args)
        {
            List<Foo> intList = new List<Foo>();
            intList.Add(new Bar());
        }
    }
}
