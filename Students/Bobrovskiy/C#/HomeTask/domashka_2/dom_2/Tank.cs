using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace dom_2
{
    class ConsoleFigure
    {
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public string FigureDescription
        {
            get;
            set;
        }
        protected void setCursorPosition(int x, int y)
        {
            System.Console.CursorLeft = x;
            System.Console.CursorTop = y;
        }
        public void draw(int x, int y, ConsoleColor figureColor)
        {
            setCursorPosition(x, y);
            setFigureColor(figureColor, figureColor);
            System.Console.Write("*");
            System.Console.CursorLeft = X;
            System.Console.CursorTop = Y;
            restoreConsoleColor();
        }
        protected void setFigureColor(ConsoleColor simbolsColor, ConsoleColor backgroundColor)
        {
            System.Console.ForegroundColor = simbolsColor;
            System.Console.BackgroundColor = backgroundColor;
        }
        protected void restoreConsoleColor()
        {
            System.Console.ResetColor();
        }
        protected void wait(int waitTime)
        {
            Thread.Sleep(waitTime);
        }
    }
    class ConsoleSquare : ConsoleFigure
    {
        public readonly int Width = 1;
        public readonly int Heigth = 1;

        public ConsoleSquare(int width, int height)
        {
            this.Width = width;
            this.Heigth = height;
        }

        public void drawSquare(int x, int y, ConsoleColor figureColor)
        {
           // setCursorPosition(x, y);
            setFigureColor(figureColor, figureColor);

            int prevTop = System.Console.CursorTop;
            int prevLeft = System.Console.CursorLeft;

            for (int i = 0; i < this.Width; ++i)
            {
                for (int j = 0; j < this.Heigth; ++j)
                {
                    System.Console.Write("♦");
                }
                System.Console.CursorTop += 1;
                System.Console.CursorLeft = prevLeft;
            }

            restoreConsoleColor();
        }

        public static void drawSquare(int left, int top, int width, int height, ConsoleColor figureColor)
        {
            ConsoleSquare mySquare = new ConsoleSquare(height, width);
            mySquare.drawSquare(left, top, figureColor);
        }

    };
    //-----------------
    class Tank
    {
        enum sizes { tankWidth = 7, tankHeight = 7, basePositionX = 40, basePositionY = 40 };
        enum mooveSpeed { level1 = 1, level2 = 2, level3 = 3, level4 = 4 };
        enum direction { up = 1, down = 2, left = 3, right = 4 };
        int curDirection = 1;

        void setBaseTankPosition() {
            System.Console.CursorLeft = (int)sizes.basePositionX;
            System.Console.CursorTop = (int)sizes.basePositionY;
        }
        //----
        void drawClearTank(int left) 
        {//up
            for (int i = 0; i < (int)sizes.tankWidth; ++i)
            {
                for (int j = 0; j < (int)sizes.tankHeight; ++j)
                {
                    setColor(System.ConsoleColor.Gray, System.ConsoleColor.Gray);
                   System.Console.Write("♦");
                }

                System.Console.CursorTop -= 1;
                System.Console.CursorLeft = left;
            }

        }
        //----
        void drawColoredTankD(int left)
        {//down
            for (int j = 0; j <(int)sizes.tankHeight;  ++j)
            {
                for (int i = 0; i < (int)sizes.tankWidth; ++i)
                {
                    setColor(System.ConsoleColor.DarkGreen, System.ConsoleColor.DarkGreen);
                    //-gysenuci-
                    if (j == 0) 
                        setColor(System.ConsoleColor.DarkBlue, System.ConsoleColor.DarkBlue);
                    if (j == (int)sizes.tankHeight - 1) 
                        setColor(System.ConsoleColor.DarkBlue, System.ConsoleColor.DarkBlue);
                    //-bashna-
                    if ((i > 0) && (i < (int)sizes.tankWidth - 2) && (j > 0) && (j < (int)sizes.tankHeight - 1)) 
                        setColor(System.ConsoleColor.DarkRed, System.ConsoleColor.DarkRed);
                    //-dylo-
                    if ((j == (int)sizes.tankHeight / 2) && i > ((int)sizes.tankWidth / 2))
                        setColor(System.ConsoleColor.DarkRed, System.ConsoleColor.DarkRed);
                    //--vurizu-
                    if ((i == (int)sizes.tankWidth - 1) && (j == (int)sizes.tankHeight - 2)) 
                        setColor(System.ConsoleColor.Gray, System.ConsoleColor.Gray);
                    if ((i == (int)sizes.tankWidth - 1) && (j == (int)sizes.tankHeight - 3)) 
                        setColor(System.ConsoleColor.Gray, System.ConsoleColor.Gray);
                    //-----
                    if ((i == (int)sizes.tankWidth - 1) && (j == 1)) 
                        setColor(System.ConsoleColor.Gray, System.ConsoleColor.Gray);
                    if ((i == (int)sizes.tankWidth - 1) && (j == 2)) 
                        setColor(System.ConsoleColor.Gray, System.ConsoleColor.Gray);
                    //-----                 
                    System.Console.Write("♦");
                }

                //if (curDirection == (int)direction.up)
                //    System.Console.CursorTop -= 1;
                //if (curDirection == (int)direction.down)
                    System.Console.CursorTop += 1;

                System.Console.CursorLeft = left;
            }

        }
        //----
        void drawColoredTank( int left) {//up
            for (int i = 0; i < (int)sizes.tankWidth; ++i)
            {                   
                for (int j = 0; j < (int)sizes.tankHeight; ++j)
                {
                    setColor(System.ConsoleColor.DarkGreen, System.ConsoleColor.DarkGreen);
                    //-gysenuci-
                    if (j == 0) setColor(System.ConsoleColor.DarkBlue, System.ConsoleColor.DarkBlue);
                    if (j == (int)sizes.tankHeight-1) setColor(System.ConsoleColor.DarkBlue, System.ConsoleColor.DarkBlue);
                    //-bashna-
                    if ((i > 0) && (i < (int)sizes.tankWidth - 2) && (j > 0) && (j < (int)sizes.tankHeight - 1)) setColor(System.ConsoleColor.DarkRed, System.ConsoleColor.DarkRed);
                    //-dylo-
                    if ((j == (int)sizes.tankHeight / 2) && i > ((int)sizes.tankWidth / 2)) setColor(System.ConsoleColor.DarkRed, System.ConsoleColor.DarkRed);
                    //--vurizu-
                    if ((i == (int)sizes.tankWidth - 1) && (j == (int)sizes.tankHeight - 2)) setColor(System.ConsoleColor.Gray, System.ConsoleColor.Gray);
                    if ((i == (int)sizes.tankWidth - 1) && (j == (int)sizes.tankHeight - 3)) setColor(System.ConsoleColor.Gray, System.ConsoleColor.Gray);
                    //-----
                    if ((i == (int)sizes.tankWidth - 1) && (j == 1)) setColor(System.ConsoleColor.Gray, System.ConsoleColor.Gray);
                    if ((i == (int)sizes.tankWidth - 1) && (j == 2)) setColor(System.ConsoleColor.Gray, System.ConsoleColor.Gray);
                    //-----                 
                    System.Console.Write("♦");
                }
                if (curDirection == (int)direction.up)
                   System.Console.CursorTop -= 1;
                if (curDirection == (int)direction.down)
                   System.Console.CursorTop += 1;

                System.Console.CursorLeft = left;
            }
        
        }
        void setColor(ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            System.Console.ForegroundColor = textColor;
            System.Console.BackgroundColor = backgroundColor;  
        }

        void setDefaultColors()
        {
            setColor(System.ConsoleColor.DarkBlue, System.ConsoleColor.Gray);
        }

        void mooveTank(string key, int side){
            switch (key)
            {
                case "W":
                    {
                        curDirection = (int)direction.up;
                        if (System.Console.CursorTop > side)
                            System.Console.CursorTop -= 1;
                    } break;
                case "S":
                    {
                        curDirection = (int)direction.down;
                        if (System.Console.CursorTop < (70 - side))
                            System.Console.CursorTop += 1;
                    } break;
                case "A":
                    {
                        curDirection = (int)direction.left;
                        if (System.Console.CursorLeft > 1)
                            System.Console.CursorLeft -= 1;
                    } break;
                case "D":
                    {
                        curDirection = (int)direction.right;
                        if (System.Console.CursorLeft < (71))
                            System.Console.CursorLeft += 1;
                    } break;
            }
        }

        public void draw() {
            System.Console.Clear();
            ConsoleKeyInfo cki;

            setDefaultColors();

            int side = (int)sizes.tankWidth;
            //--
            System.Console.Clear();
            string key = string.Empty;
            System.Console.Write("Для виходу натиснiть (ESC) керування (W,S,A,D) ");
            //--
            setBaseTankPosition();
            //--          
            System.Console.CursorVisible = false;
            do
            {                
                cki = Console.ReadKey(true);
                key = cki.Key.ToString();
                //----------               
                int prevLeft1 = System.Console.CursorLeft;
                int prevTop1 = System.Console.CursorTop;
                drawClearTank(prevLeft1);
                System.Console.CursorTop = prevTop1;             
                //-----------
                 mooveTank(key, side);
                //-----------
                int prevLeft = System.Console.CursorLeft;
                int prevTop = System.Console.CursorTop;

                drawColoredTank(prevLeft);

                System.Console.CursorTop = prevTop;                      
                
            } while (key != "Escape");
            //--
            System.Console.ReadKey();

        }
    }
    //-----------------
    class ConsoleTank {
        enum sizes { tankWidth = 4, tankHeight = 7, basePositionX = 40, basePositionY = 40 };
        enum mooveSpeed { level1 = 1, level2 = 2, level3 = 3, level4 = 4 };
        enum direction { up = 1, down = 2, left = 3, right = 4 };
        int curDirection = 1;

        void setBaseTankPosition()
        {
            System.Console.CursorLeft = (int)sizes.basePositionX;
            System.Console.CursorTop = (int)sizes.basePositionY;
        }
        //---- 
        public void setCursorPosition(int x, int y)
        {
            System.Console.CursorLeft = x;
            System.Console.CursorTop = y;
        }
        //--
        void drawClearTank(int left, int top)
        {//up
            ConsoleSquare.drawSquare(left-1, top-1, 7, 7, ConsoleColor.Gray);           
            setCursorPosition(left, top);         
        }        
        //----
        void drawColoredTankUp(int left,int top)
        {//up
            ConsoleSquare.drawSquare(left, top, 5, 5, ConsoleColor.Red);
            setCursorPosition(left, top+1);
            ConsoleSquare.drawSquare(left, top, 1, 4, ConsoleColor.DarkGreen);
            setCursorPosition(left+4, top+1);
            ConsoleSquare.drawSquare(left, top, 1, 4, ConsoleColor.DarkGreen);
            setCursorPosition(left + 2, top);
            ConsoleSquare.drawSquare(left, top, 1, 3, ConsoleColor.DarkGreen);
            setCursorPosition(left + 1, top + 2);
            ConsoleSquare.drawSquare(left, top, 3, 2, ConsoleColor.DarkBlue);
            setCursorPosition(left, top);
        }
        void drawColoredTankDown(int left, int top)
        {
            ConsoleSquare.drawSquare(left, top, 5, 5, ConsoleColor.Red);
            setCursorPosition(left, top);
            ConsoleSquare.drawSquare(left, top, 1, 4, ConsoleColor.DarkGreen);
            setCursorPosition(left + 4, top);
            ConsoleSquare.drawSquare(left, top, 1, 4, ConsoleColor.DarkGreen);
            setCursorPosition(left + 2, top+2);
            ConsoleSquare.drawSquare(left, top, 1, 3, ConsoleColor.DarkGreen);
            setCursorPosition(left + 1, top+1);
            ConsoleSquare.drawSquare(left, top, 3, 2, ConsoleColor.DarkBlue);
            setCursorPosition(left, top);
        }
        void drawColoredTankRight(int left, int top) {
            
            ConsoleSquare.drawSquare(left, top, 7, 5, ConsoleColor.Red);
            setCursorPosition(left, top);
            ConsoleSquare.drawSquare(left, top, 5, 1, ConsoleColor.DarkGreen);

            setCursorPosition(left , top+4);
            ConsoleSquare.drawSquare(left, top, 5, 1, ConsoleColor.DarkGreen);

            setCursorPosition(left + 2, top + 2);
            ConsoleSquare.drawSquare(left, top, 5, 1, ConsoleColor.DarkGreen);

            setCursorPosition(left + 1, top + 1);
            ConsoleSquare.drawSquare(left, top, 3, 3, ConsoleColor.DarkBlue);

            setCursorPosition(left, top);
        }
        void drawColoredTankLeft(int left, int top) {

            ConsoleSquare.drawSquare(left, top, 7, 5, ConsoleColor.Red);
            setCursorPosition(left+2, top);
            ConsoleSquare.drawSquare(left, top, 5, 1, ConsoleColor.DarkGreen);

            setCursorPosition(left+2, top + 4);
            ConsoleSquare.drawSquare(left, top, 5, 1, ConsoleColor.DarkGreen);

            setCursorPosition(left , top + 2);
            ConsoleSquare.drawSquare(left, top, 5, 1, ConsoleColor.DarkGreen);

            setCursorPosition(left + 3, top + 1);
            ConsoleSquare.drawSquare(left, top, 3, 3, ConsoleColor.DarkBlue);

            setCursorPosition(left, top);
        }
        //------------------
        void drawTank(int dir, int left, int top) {
            switch (dir) {
                case (int)direction.up: {
                    drawColoredTankUp(left, top);
                } break;
                case (int)direction.down: {
                    drawColoredTankDown(left, top);
                } break;
                case (int)direction.left: { 
                    drawColoredTankLeft(left, top);
                } break;
                case (int)direction.right: {
                    drawColoredTankRight(left, top);
                } break;
            }
        
        }
        //------------------
        void setColor(ConsoleColor textColor, ConsoleColor backgroundColor)
        {
            System.Console.ForegroundColor = textColor;
            System.Console.BackgroundColor = backgroundColor;
        }

        void setDefaultColors()
        {
            setColor(System.ConsoleColor.DarkBlue, System.ConsoleColor.Gray);
        }

        void mooveTank(string key, int side)
        {
            switch (key)
            {
                case "W":
                    {
                        curDirection = (int)direction.up;
                        if (System.Console.CursorTop >= side)
                            System.Console.CursorTop -= 1;
                    } break;
                case "S":
                    {
                        curDirection = (int)direction.down;
                        if (System.Console.CursorTop < (70 - side))
                            System.Console.CursorTop += 1;
                    } break;
                case "A":
                    {
                        curDirection = (int)direction.left;
                        if (System.Console.CursorLeft > 1)
                            System.Console.CursorLeft -= 1;
                    } break;
                case "D":
                    {
                        curDirection = (int)direction.right;
                        if (System.Console.CursorLeft < (71))
                            System.Console.CursorLeft += 1;
                    } break;
            }
        }

        public void draw()
        {
            System.Console.Clear();
            ConsoleKeyInfo cki;

            setDefaultColors();

            int side = (int)sizes.tankWidth;
            //--
            System.Console.Clear();
            string key = string.Empty;
            System.Console.Write("Для виходу натиснiть (ESC) керування (W,S,A,D) ");
            //--
            setBaseTankPosition();
            //--          
            System.Console.CursorVisible = false;
            do
            {
                cki = Console.ReadKey(true);
                key = cki.Key.ToString();
                //----------               
                int prevLeft1 = System.Console.CursorLeft;
                int prevTop1 = System.Console.CursorTop;
                drawClearTank(prevLeft1, prevTop1);
                System.Console.CursorTop = prevTop1;
                //-----------
                mooveTank(key, side);
                //-----------
                int prevLeft = System.Console.CursorLeft;
                int prevTop = System.Console.CursorTop;

                drawTank(curDirection, prevLeft, prevTop);
                
                System.Console.CursorTop = prevTop;

            } while (key != "Escape");
            //--
            System.Console.ReadKey();

        }
    }
}
