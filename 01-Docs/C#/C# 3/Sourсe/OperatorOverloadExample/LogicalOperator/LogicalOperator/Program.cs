using System;

public struct DBBool
{
    //три возможных значения
    // Значение параметра может быть: - 1(false), 1 - true и 0 - null.
    public static readonly DBBool Null = new DBBool(0);
    public static readonly DBBool False = new DBBool(-1);
    public static readonly DBBool True = new DBBool(1);
    
    sbyte value;

    DBBool(int value)
    {
        this.value = (sbyte)value;
    }

    public DBBool(DBBool b)
    {
        this.value = (sbyte)b.value;
    }
    
    // Оператор Логическое И. Возвращает:
    // False, если один из операндов False независимо от 2-ого операнда
    // Null, если один из операндов Null,ь а другой Null или True
    // True, если оба операнда True
    public static DBBool operator &(DBBool x, DBBool y)
    {
        return new DBBool(x.value < y.value ? x.value : y.value);
    }

     // Оператор Логическое ИЛИ. Возвращает:
    // True, если один из операндов True независимо от 2-ого операнда
    // Null, если один из операндов Null, а другой False или Null
    // False, если оба операнда False
    public static DBBool operator |(DBBool x, DBBool y)
    {
        return new DBBool(x.value > y.value ? x.value : y.value);
    }

    // Оператор Логической инверсии. Возвращает:
    // False, если операнд содержит True
    // True, если операнд содержит False
    // Null, если операнд содержит Null
    public static DBBool operator !(DBBool x)
    {
        return new DBBool(-x.value);
    }

    // Возвращает true, если в операнде содержится True,
    // иначе возвращает false
    public static bool operator true(DBBool x)
    {
        return x.value > 0;
    }
    // Возвращает true, если в операнде содержится False,
    // иначе возвращает false
    public static bool operator false(DBBool x)
    {
        return x.value < 0;
    }

    public override string ToString()
    {
        if (value > 0) return "DBBool.True";
        if (value < 0) return "DBBool.False";
        return "DBBool.Null";
    }
}

class Test
{
    static void Main()
    {
        DBBool bTrue = new DBBool(DBBool.True);
        DBBool bNull = new DBBool(DBBool.Null);
        DBBool bFalse = new DBBool(DBBool.False);

        Console.WriteLine("bTrue && bNull is {0}", bTrue && bNull);
        Console.WriteLine("bTrue && bFalse is {0}", bTrue && bFalse);
        Console.WriteLine("bTrue && bTrue is {0}", bTrue && bTrue);
        Console.WriteLine();

        Console.WriteLine("bTrue || bNull is {0}", bTrue || bNull);
        Console.WriteLine("bFalse || bFalse is {0}", bFalse || bFalse);
        Console.WriteLine("bTrue || bFalse is {0}", bTrue || bFalse);
        Console.WriteLine();

        Console.WriteLine("!bTrue is {0}", !bTrue);
        Console.WriteLine("!bFalse is {0}", !bFalse);
        Console.WriteLine("!bNull is {0}", !bNull);
        Console.ReadLine();
    }
}

