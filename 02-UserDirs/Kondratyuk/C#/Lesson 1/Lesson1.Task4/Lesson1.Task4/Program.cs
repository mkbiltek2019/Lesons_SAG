using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1.Task4
{
    
    static class StringReverse
    {
    public static string ReverseString(string s)
    {
	    char[] arr = s.ToCharArray();
	    Array.Reverse(arr);
	    return new string(arr);
    }
}
    
    class Program
    {
        static void Main(string[] args)
        {
        Console.Write("Введите целое число N>0 =:");
        string N=Console.ReadLine();

        Console.WriteLine("Зеркальное отображение N:= {0}", StringReverse.ReverseString(N));   
        }
    }
}
