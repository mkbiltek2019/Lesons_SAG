using System;

namespace StringMethodsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "hello :)";
            object anotherString = str.Clone();
            Console.WriteLine(anotherString);
            //выводит: "hello :)"
            Console.WriteLine(str.Contains("hello"));
            //выводит: true
            Console.WriteLine(str.Insert(6, "world"));
            //выводит: "hello world:)"
            Console.WriteLine(str.Remove(5, 1));
            //выводит: "hello:)"
            Console.WriteLine(str.Replace(":)", ":("));
            //выводит: "hello :("
            Console.WriteLine(str.StartsWith("hell"));
            //выводит: "true"
            Console.WriteLine(str.Substring(6));
            //выводит: ":)"
            Console.WriteLine(str.ToUpper());
            //выводит: "HELLO :)"
            str = "       " + str + "       ";
            Console.WriteLine(str.TrimEnd());
            //выводит: "       hello :)"
            str = "       " + str + "       ";
            str = str.Trim();
            Console.WriteLine(str);
            //выводит: "hello :)"
            Console.WriteLine(string.Format("the message is \"{0}\" and some numeric value is {1}", str, 512));
            //выводит: "the message is "hello :)" and some numeric value is 512"
        }
    }
}
