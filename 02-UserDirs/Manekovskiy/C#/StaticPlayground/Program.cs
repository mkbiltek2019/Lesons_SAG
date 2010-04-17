using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StaticPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleWrapper.WriteLineWithColor("Hello world!");
            ConsoleWrapper.WriteLineWithColor("Hello world!", ConsoleColor.DarkYellow);
            ConsoleWrapper.ForegroundColor = ConsoleColor.Green;
            ConsoleWrapper.WriteLineWithColor("Hello world!");
        }
    }

    public static class ConsoleWrapper
    {
        private static ConsoleColor foregroundColor;
        public static ConsoleColor ForegroundColor
        {
            get
            {
                return foregroundColor;
            }
            set
            {
                foregroundColor = value;
            }
        }

        static ConsoleWrapper()
        {
            foregroundColor = ConsoleColor.Magenta;
        }

        public static void WriteLineWithColor(string text, ConsoleColor foregroundColor)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;
        }

        public static void WriteLineWithColor(string text)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ForegroundColor;
            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;
        }
    }
}
