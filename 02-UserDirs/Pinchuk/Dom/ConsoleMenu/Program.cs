using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpers.Abstraction;
using Helpers.Console;

namespace ConsoleMenuSample
{

    public delegate void FunctionHandlerWithTwoIntegerParametersThatReturnsVoid(int parameter1, int parameter2);
    #region Calc
    /*
    public class Calculator
    {
        public void AddTwoIntegerParameters(int number1, int number2)
        {
            Console.WriteLine("{0} + {1} = {2}", number1, number2, number1 + number2);
        }

        public void MultiplyWithTwoIntegerParameters(int number1, int number2)
        {
            Console.WriteLine("{0} * {1} = {2}", number1, number2, number1 * number2);
        }

        public void SubstractWithTwoIntegerParameters(int number1, int number2)
        {
            Console.WriteLine("{0} - {1} = {2}", number1, number2, number1 - number2);
        }

        public void DivideWithTwoIntegerParameters(int number1, int number2)
        {
            Console.WriteLine("{0} / {1} = {2}", number1, number2, number1 / number2);
        }
    }
     */
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            #region delegat
            /*
            FunctionHandlerWithTwoIntegerParametersThatReturnsVoid functionHandler;
            Calculator calc = new Calculator();

            functionHandler = new FunctionHandlerWithTwoIntegerParametersThatReturnsVoid(calc.AddTwoIntegerParameters);
            functionHandler += calc.MultiplyWithTwoIntegerParameters;
            functionHandler += calc.SubstractWithTwoIntegerParameters;
            functionHandler += calc.DivideWithTwoIntegerParameters;

            functionHandler.Invoke(2, 3);

            functionHandler -= calc.SubstractWithTwoIntegerParameters;

            functionHandler.Invoke(2, 3);
            #endregion
            Console.WriteLine("What to do?");
            Console.WriteLine("1. Add 2 and 3");
            Console.WriteLine("2. Multiply 2 and 3");
            ConsoleKeyInfo selected = Console.ReadKey(true);

            Calculator calc = new Calculator();
            
            switch (selected.Key)
            {
                case ConsoleKey.NumPad1:
                    functionHandler = new FunctionHandlerWithTwoIntegerParametersThatReturnsVoid(calc.AddTwoIntegerParameters);
                    break;
                case ConsoleKey.NumPad2:
                    functionHandler = new FunctionHandlerWithTwoIntegerParametersThatReturnsVoid(calc.MultiplyWithTwoIntegerParameters);
                    break;
                default:
                    functionHandler = new FunctionHandlerWithTwoIntegerParametersThatReturnsVoid(calc.MultiplyWithTwoIntegerParameters);
                    break;
            }

            functionHandler.Invoke(2, 3);

             */
            #endregion
            ConsoleMenu mainMenu = new ConsoleMenu(
                new ConsoleMenu.ConsoleMenuItem[] 
                {
                    new ConsoleMenu.ConsoleMenuItem() { Key = "1", Description = "Print hello world", Visible = true },
                    new ConsoleMenu.ConsoleMenuItem() { Key = "2", Description = "Print goodbye world", Visible = true },
                    new ConsoleMenu.ConsoleMenuItem() { Key = "3", Description = "Exit from menu", Visible = false },
                    new ConsoleMenu.ConsoleMenuItem() { Key = "4", Description = "Options", Visible = true }
                }
            );

            mainMenu.NextMenuItemKey = ConsoleKey.DownArrow;
            mainMenu.PreviousMenuItemKey = ConsoleKey.UpArrow;
            mainMenu.SelectMenuItemKey = ConsoleKey.Enter;

            try
            {
                if (!OperatorArray.ArrayRepl(mainMenu.MenuItems))
                    throw new Exception("Одиковые ключи");
                mainMenu.Display();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception:{0}", e.Message);
            }





        }
    }
}
