using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ArrayListPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arrayList = new ArrayList(2);

            Console.WriteLine("Capacity = {0}", arrayList.Capacity);
            Console.WriteLine("Count = {0}", arrayList.Count);
            arrayList.Add(1);
            arrayList.Add(":aasdasdasdqity 398t ");
            arrayList.Add(new int[] { 11, 2, 3, 45 });
            Console.WriteLine("Capacity = {0}", arrayList.Capacity);
            Console.WriteLine("Count = {0}", arrayList.Count);

            arrayList.Add(1);
            arrayList.Add(1);
            Console.WriteLine("Capacity = {0}", arrayList.Capacity);
            Console.WriteLine("Count = {0}", arrayList.Count);


            ArrayList fixedArrayList = ArrayList.FixedSize(arrayList);
            fixedArrayList[0] = 2;
            fixedArrayList[1] = 2;
            foreach (object integer in fixedArrayList)
            {
                Console.WriteLine(integer);
            }

            //Type int32Type = Type.GetType("System.Int32");
            //Control createdInt = Activator.CreateInstance(int32Type) as Control;
            
            //Console.WriteLine(createdInt);
        }
    }
}