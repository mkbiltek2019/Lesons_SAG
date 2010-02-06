using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASCIITank
{
    class Program
    {
        static void Main(string[] args)
        {
            Tank tank = new Tank();
            int currentX = 0;
            int currentY = 10;
            tank.DrawForward(currentX, currentY);

            bool exit = false;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow :
                        currentX--;
                        tank.DrawBackward(currentX, currentY);
                        break;
                    case ConsoleKey.RightArrow :
                        currentX++;
                        tank.DrawForward(currentX, currentY);
                        break;
                    case ConsoleKey.Escape :
                        exit = true;
                        break;
                }

            } while (!exit);
        }
    }

    public class Tank
    {
        private string[] tankForward = new string[] {
            @" |            ",
            @" |/----\      ",
            @" /  453 \====(",
            @" ========     ",             
            @"(0o0o0o0o0)   "};
        private string[] tankBackward = new string[] {
            @"            |  ",
            @"      /----\|  ",
            @")====/  453 \  ",
            @"     ========  ",             
            @"    (0o0o0o0o0)"};

        public void DrawForward(int x, int y)
        {
            for (int currentLine = 0; currentLine < tankForward.Length; currentLine++)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y + currentLine;
                Console.WriteLine(tankForward[currentLine]);
            }
        }

        public void DrawBackward(int x, int y)
        {
            for (int currentLine = 0; currentLine < tankForward.Length; currentLine++)
            {
                Console.CursorLeft = x;
                Console.CursorTop = y + currentLine;
                Console.WriteLine(tankBackward[currentLine]);
            }
        }
    }
}