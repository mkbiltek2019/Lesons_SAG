using System;
using System.Collections;

public class SortedArrayList : ArrayList
{
    public void AddSorted(object item)
    {
        int position = this.BinarySearch(item);

        if (position < 0)
        {
            position = ~position;
        }

        this.Insert(position, item);
    }

    public void ModifySorted(object item, int index)
    {
        this.RemoveAt(index);

        int position = this.BinarySearch(item);
        if (position < 0)
        {
            position = ~position;
        }

        this.Insert(position, item);
    }
}
class CTest
{
    static void Main()
    {
        // Create a SortedArrayList and populate it with 
        //    randomly choosen numbers
        SortedArrayList sortedAL = new SortedArrayList();
        sortedAL.AddSorted(200);
        sortedAL.AddSorted(-7);
        sortedAL.AddSorted(0);
        sortedAL.AddSorted(-20);
        sortedAL.AddSorted(56);
        sortedAL.AddSorted(200);

        // Display it
        foreach (int i in sortedAL)
        {
            Console.Write(i+ " ");
        }

        // Now modify a value at a particular index
        sortedAL.ModifySorted(3, 5);
        sortedAL.ModifySorted(-1, 2);
        sortedAL.ModifySorted(2, 4);
        sortedAL.ModifySorted(7, 3);

        Console.WriteLine();
        // Display it
        Console.WriteLine();
        foreach (int i in sortedAL)
        {
            Console.Write(i + " ");
        }
    }
}
