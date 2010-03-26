using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CockroachRaces
{
    public static class PrintConsole
    {
        public static void PrintRacetrack()
        { 
            Console.WriteLine("Марафон");
            for (int j = 0; j < 15; j += 6)
            {
                PrintSymbolRows(Console.WindowWidth, "-", 2 + j);
                PrintSymbolColumm(5, "|", 5, 3 + j);
                PrintSymbolColumm(5, "|", Console.WindowWidth-10, 3 + j);
                WriteSymbolNewLine("START ", 6, 3 + j);
                PrintSymbolRows(Console.WindowWidth, "-", 8 + j);
            }

        }
        public static void PrintSymbolRows(int count, string symbol, int y)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                Console.CursorTop = y;
                Console.Write(symbol);
            }
        }
        public static void PrintSymbolColumm(int count, string symbol, int x, int y)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y+i;
                Console.WriteLine(symbol);
            }
        }

        public static void WriteSymbolNewLine(string symbol, int x, int y)
        {
            for (int i = 0; i < symbol.Length; i++)
            {
                PositionCursorSet(x, y + i);
                Console.WriteLine(symbol[i]);
            }
        }
        public static void PositionCursorSet(int x, int y)
        {
            Console.CursorTop = y;
            Console.CursorLeft = x;
        }
    }
}
