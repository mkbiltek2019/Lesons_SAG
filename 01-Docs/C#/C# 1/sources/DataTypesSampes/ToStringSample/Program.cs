using System;

namespace ToStringSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prg = new Program();
            Console.WriteLine(prg.ToString());
            /*В консоль выводиться текст: ToStringSample.Program
            что соответствует имени основного класса нашей программы
            в системе типов .NET Framework*/            
        }
    }
}
