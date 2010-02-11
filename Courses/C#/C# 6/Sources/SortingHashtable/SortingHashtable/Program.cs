using System;
using System.Collections;

public class mySortedHashtable
{
   private Hashtable hash = new Hashtable();
    // Return an ArrayList of Hashtable keys
    public ArrayList GetKeys(Hashtable table)
    {
        return (new ArrayList(table.Keys));
    }

    // Return an ArrayList of Hashtable values
    public ArrayList GetValues(Hashtable table)
    {
        return (new ArrayList(table.Values));
    }

    public void FillIn(object x, object y)
    {
        hash.Add(x, y);
    }

    public void TestSortKeyValues()
    {
        // Get all the keys in the hashtable and sort them
        ArrayList keys = GetKeys(hash);
        keys.Sort();

        // Display sorted key list
        foreach (object obj in keys)
            Console.WriteLine("Key: " + obj + "    Value: " + hash[obj]);

        // Reverse the sorted key list
        Console.WriteLine();
        keys.Reverse();

        // Display reversed key list
        foreach (object obj in keys)
            Console.WriteLine("Key: " + obj + "    Value: " + hash[obj]);

        // Get all the values in the hashtable and sort them
        Console.WriteLine();
        Console.WriteLine();

        ArrayList values = GetValues(hash);
        values.Sort();

        foreach (object obj in values)
            Console.WriteLine("Value: " + obj);

        // Reverse the sorted value list
        Console.WriteLine();
        values.Reverse();

        foreach (object obj in values)
            Console.WriteLine("Value: " + obj);
    }
}
public class Tester
{
    public static void Main()
    {
        mySortedHashtable coll = new mySortedHashtable();
        coll.FillIn(2, "two");
        coll.FillIn(1, "one");
        coll.FillIn(5, "five");
        coll.FillIn(3, "three");
        coll.TestSortKeyValues();
    }
}
