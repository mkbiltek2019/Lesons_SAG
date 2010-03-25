using System;

namespace ConsoleApplication1
{
    public static class RunnerVisualizer
    {
       public static string[] runnerConsoleImage = new string[] 
       {
           @"  .-./*)",
           @"-/___\/ ",
           @"  U U   "
       };

        public static void drawColoredTurtle(int top, int left, ConsoleColor color)
        {
            for (int currentLine = 0; currentLine < runnerConsoleImage.Length; currentLine++)
            {
                SetColor(color);
                Console.CursorLeft = left;
                Console.CursorTop = top + currentLine;
                Console.WriteLine(runnerConsoleImage[currentLine]);
            }
        }

        public static void drawClearTurtle(int top, int left)
        {
            for (int currentLine = 0; currentLine < runnerConsoleImage.Length; currentLine++)
            {
                SetColor(ConsoleColor.Black);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.CursorLeft = left;
                Console.CursorTop = top + currentLine;
                Console.WriteLine(runnerConsoleImage[currentLine]);
            }
        }

        public static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}
