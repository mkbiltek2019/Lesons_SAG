using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleSimpleGraphicFigure
{
    #region Interface declaration
    public interface IDrawable
    {
        int Top
        {
            get;
        }
        int Left
        {
            get;
        }

        void Draw();
    }
    #endregion

    public abstract class Figure {
        public string FigureDescription
        {
            get;
            set;
        }
        public abstract void Draw();        
    }

    public abstract class FigureWithAcuteSides : Figure, IDrawable
    {
        #region IDrawable Members

        public int Top
        {
            get;
            set;
        }

        public int Left
        {
            get;
            set;
        }
        public override void Draw(){} 
        #endregion
        
    }

    public abstract class FigureWithRoundedSides : Figure, IDrawable
    {
        #region IDrawable Members

        public int Top
        {
            get;
            set;
        }

        public int Left
        {
            get;
            set;
        }
        public override void Draw() { }
        #endregion
    }

    public static class  ConsoleWrapper{
        private static int prevTop;
        private static int prevLeft;

        public static void setCursorPosition(int left, int top)
        {
            prevTop = top;
            prevLeft = left;
            System.Console.CursorLeft = left;
            System.Console.CursorTop = top;
        }
        public static void restoreCursorPosition() {
            System.Console.CursorLeft = prevLeft;
            System.Console.CursorTop = prevTop;
        }
        public static void restoreCursorLeft(){
            System.Console.CursorLeft = prevLeft;
        }
        public static void restoreCursorTop() {
            System.Console.CursorTop = prevTop;
        }

        public static void setFigureColor(ConsoleColor simbolsColor, ConsoleColor backgroundColor)
        {
            System.Console.ForegroundColor = simbolsColor;
            System.Console.BackgroundColor = backgroundColor;
        }
        public static void setColor(ConsoleColor color)
        {
            System.Console.ForegroundColor = color;
            System.Console.BackgroundColor = color;
        }
        public static void restoreConsoleColor()
        {
            System.Console.ResetColor();
        }
        public static void wait(int waitTime)
        {
            Thread.Sleep(waitTime);
        }
        public static void WriteSimbol(char simbol) {
            System.Console.Write("{0}", simbol);
        }

    }
    
    public class ConsoleRectangle : FigureWithAcuteSides
    {
        private int width;
        private int height;

        public int Width {
            get {
                return width;
            }
            set {
                width = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public ConsoleRectangle() 
        {
            this.FigureDescription = "Console Square";
            this.Left = 0;
            this.Top = 0;
            this.Width = 1;
            this.Height = 1;
        }
        
        public void DrawFilledRectangle(int top, int left, int width, int height, ConsoleColor color) {
           
            this.width = width;
            this.height = height;

            ConsoleWrapper.setCursorPosition(left,top);
            ConsoleWrapper.setColor(color);

            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    ConsoleWrapper.WriteSimbol('♦');                   
                }
                ConsoleWrapper.restoreCursorLeft();
                ConsoleWrapper.setCursorPosition(System.Console.CursorLeft, ++System.Console.CursorTop);
               
            }

            ConsoleWrapper.restoreConsoleColor();
            ConsoleWrapper.restoreCursorPosition();
            
        }
    }

    public class ConsoleCircle : FigureWithRoundedSides
    {
        private int circleRadius;

        public int CircleRadius
        {
            get
            {
                return circleRadius;
            }
            set
            {
                circleRadius = value;
            }
        }
        
        public ConsoleCircle()
        {
            circleRadius = 1;
        }

        public void drawCircle(int left, int top, int radius, ConsoleColor color)
        {
            circleRadius = radius;

            ConsoleWrapper.setCursorPosition(left, top);
            ConsoleWrapper.setColor(color);

            double theta = 0;
            double increment = 0; 
            double xF = 0;             
            
            int x = 0;
            int xN = 0;
            int yN = 0;

            increment = (double)0.8 / (double)(circleRadius);

            for (theta = 0; theta <= Math.PI / 2; theta += increment)
            {
                xF = (double)circleRadius * Math.Cos(theta);

                xN = (int)(xF * 2 / 1);

                yN = (int)(circleRadius * Math.Sin(theta) + 0.5);

                x = left - xN;

                while (x <= left + xN)
                {
                    ConsoleWrapper.setCursorPosition(x, top - yN);
                    ConsoleWrapper.WriteSimbol('♦');

                    ConsoleWrapper.setCursorPosition(x++, top + yN);
                    ConsoleWrapper.WriteSimbol('♦');
                }//while
            }//for              

            ConsoleWrapper.restoreConsoleColor();
            ConsoleWrapper.restoreCursorPosition();
        }

    }

    public class ConsoleTriangle : FigureWithAcuteSides
    {
        private int triangleHeigth;

        public int TriangleHeigth
        {
            get
            {
                return triangleHeigth;
            }
            set
            {
                triangleHeigth = value;
            }
        }
        
        public ConsoleTriangle() {
            triangleHeigth = 1;
        }

        public void drawTriangle(int left, int top, int height, ConsoleColor color)
        {
            ConsoleWrapper.setCursorPosition(left, top);
            ConsoleWrapper.setColor(color);

            int x = 0, y = 0;
            for (y = top; y < top + height; y++)
            {
                int incr = y - top;
                for (x = left - incr; x <= left + incr; x++)
                {
                    ConsoleWrapper.setCursorPosition(x, y);
                    ConsoleWrapper.WriteSimbol('♦');
                }//for
            }//for

            ConsoleWrapper.restoreConsoleColor();
            ConsoleWrapper.restoreCursorPosition();
        }
    }
   
}
