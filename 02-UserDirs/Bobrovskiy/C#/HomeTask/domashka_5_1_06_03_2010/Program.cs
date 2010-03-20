using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using MyASCIITank.MyTank;
using MyASCIITank.MyMunition;

namespace MyASCIITank
{
    class Program
    {
        static void Main(string[] args)
        {
            const int shootLength = 30;
            const int topMargin = 2;
            const int leftMargin = 14;
            const int backwardMargin = 3;
            bool exit = false;
            int munitionTop = 0;
            int munitionLeft = 0;

            ASCIITank tank = new ASCIITank();

            do
            {
                Console.BackgroundColor = ConsoleColor.Gray;

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                Console.Clear();
                Console.CursorVisible = false;

                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            tank.Move(MoveDirection.Backward);
                        } break;
                    case ConsoleKey.RightArrow:
                        {
                            tank.Move(MoveDirection.Forward);
                        } break;
                    case ConsoleKey.Enter:
                        {
                            tank.Draw();

                            switch (tank.CurentDirection) 
                            {
                                case MoveDirection.Backward:
                                    munitionTop = tank.Top + topMargin;
                                    munitionLeft = tank.Left - backwardMargin;
                                    break;
                                case MoveDirection.Forward:
                                    munitionTop = tank.Top + topMargin;
                                    munitionLeft = tank.Left + leftMargin;
                                    break;
                            }

                            Munition bullet = new Munition(munitionTop, munitionLeft, tank.CurentDirection, shootLength);
                            tank.Fire(new MunitionHandler(bullet.Moove));
                        } break;
                    case ConsoleKey.Escape:
                        {
                            exit = true;
                        } break;
                    default:
                        {
                            tank.Draw();
                        } break;
                }

            } while (!exit);
        }
    }
}