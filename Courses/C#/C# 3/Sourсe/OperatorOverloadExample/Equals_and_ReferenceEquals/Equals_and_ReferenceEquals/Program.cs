using System;

namespace Equals_and_ReferenceEquals
{
class  CPoint
 {
   private int x, y;
    public CPoint(int x, int y)
    {
        this.x = x; this.y = y;
    }
 }

struct  SPoint
{
    private int x, y;
    public SPoint(int x, int y)
    {
        this.x = x; this.y = y;
    }
}
class Program
{
    static void Main()
    {
        //Работа метода ReferenceEquals с сылочным и значимым типами
        //ссылочный тип
        CPoint p = new CPoint(0, 0);
        CPoint p1 = new CPoint(0, 0);
        CPoint p2 = p1;
        Console.WriteLine("ReferenceEquals(p, p1)= {0}", ReferenceEquals(p, p1)); //false
        //хотя p,p1содержат одинаковые значения, они указывают на разные адреса памяти
        Console.WriteLine("ReferenceEquals(p1, p2)= {0}", ReferenceEquals(p1, p2));//true
        //p1 и p2 указывают на один и тот же адрем памяти

        //значимй тип
        SPoint p3 = new SPoint(0, 0);
        //при передаче в метод ReferenceEquals выполняется упаковка, 
        //упакованные объекты располагаются по разным адресам
        Console.WriteLine("ReferenceEquals(p3, p3) =  {0}", ReferenceEquals(p3, p3)); //false

        //Работа метода Equals с сылочным и значимым типами
        //ссылочный тип
        CPoint cp = new CPoint(0, 0);
        CPoint cp1 = new CPoint(0, 0);
        Console.WriteLine("Equals(cp, cp1) =  {0}", Equals(cp, cp1)); //false
        //выполняется сравнение адресов

        //значимй тип
        SPoint sp = new SPoint(0, 0);
        SPoint sp1 = new SPoint(0, 0);
        Console.WriteLine("Equals(sp, sp1) =  {0}", Equals(sp, sp1)); //true
        //выполняется сравнение значений полей 
        Console.ReadLine();
    }
}
}
