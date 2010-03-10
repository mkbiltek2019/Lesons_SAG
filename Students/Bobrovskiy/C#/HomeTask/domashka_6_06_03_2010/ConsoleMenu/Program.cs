using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Helpers.Abstraction;
using Helpers.Console;
using Helpers.MyXmlReaderSpace;
using Helpers.MyProduct;
using Helpers.MyOrder;
using Helpers.MyCommand;

namespace ConsoleMenuSample
{
    /*
     список напоїв і їжі помістити в два арейлісти
     * при виборі вказаного подукту виводити підменю з можливістю вводу кількості
     * вцьому ж підменю виводити вартість одиниці продукту
     * після введення кількості додавати вказаний продукт до замовлення (назва продукту, ціна одиниці, кількість)
     * для збереження списку товарів в замовлення використати арейліст
     * при виводі замовлення на екран видалити всі елементи з арейліста в
     * яких кількість продуктів рівна 0
     */
    class Program
    {
        private static void HandlersToMenuItemsBinding(ArrayList itemsArray, MenuFunctionHandler[] handlersArray)
        {
            for (int i = 0; i < itemsArray.Count; i++)
            {
                ((ConsoleMenuItem)itemsArray[i]).Action = (MenuFunctionHandler)handlersArray[i];
            }
        }

        private static MenuResult MenuExit()
        {
            System.Console.WriteLine("\n");
            System.Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
            System.Console.WriteLine("│ Дякуємо ВАМ за вiдвiдування закладу швидкого харчування │");
            System.Console.WriteLine("│                    МАКДОНАЛЬДЗ                          │");
            System.Console.WriteLine("└─────────────────────────────────────────────────────────┘");
            System.Console.WriteLine("\n");
            return MenuResult.Exit;
        }

        static void Main(string[] args)
        {
            #region AdministratorAddAndShowMenu

            MyXmlReader xmlMenu1 = new MyXmlReader(@"MenuInXmlFiles\AdministratorAddAndShowMenu.xml");
            ArrayList itemsArray1 = xmlMenu1.ReadXmlMenuFileWithSpecificFormatAndReturnListOfMenuItems();

            Command commad1 = new Command();
           // commad.MenuHandler = AdministratorAddAndShowMenu.Display;

            MenuFunctionHandler[] handlersArray1 = new MenuFunctionHandler[] { 
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray1, handlersArray1);
            ConsoleMenu AdministratorAddAndShowMenu = new ConsoleMenu(itemsArray1);

            #endregion

            #region menuToOrderFood

            MyXmlReader xmlMenu3 = new MyXmlReader(@"MenuInXmlFiles\menuToOrderFood.xml");
            ArrayList itemsArray3 = xmlMenu3.ReadXmlMenuFileWithSpecificFormatAndReturnListOfMenuItems();
            MenuFunctionHandler[] handlersArray3 = new MenuFunctionHandler[] { 
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray3, handlersArray3);
            ConsoleMenu menuToOrderFood = new ConsoleMenu(itemsArray3);

            #endregion

            #region menuToOrderBeverage

            MyXmlReader xmlMenu2 = new MyXmlReader(@"MenuInXmlFiles\menuToOrderBeverage.xml");
            ArrayList itemsArray2 = xmlMenu2.ReadXmlMenuFileWithSpecificFormatAndReturnListOfMenuItems();
            MenuFunctionHandler[] handlersArray2 = new MenuFunctionHandler[] { 
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit,//corect handler
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray2, handlersArray2);
            ConsoleMenu menuToOrderBeverage = new ConsoleMenu(itemsArray2);

            #endregion

            #region menuToOrderFoodAndBeverage

            MyXmlReader xmlMenu4 = new MyXmlReader(@"MenuInXmlFiles\menuToOdrerFoodAndBeverage.xml");
            ArrayList itemsArray4 = xmlMenu4.ReadXmlMenuFileWithSpecificFormatAndReturnListOfMenuItems();

            MenuFunctionHandler[] handlersArray4 = new MenuFunctionHandler[] { 
                menuToOrderFood.Display,
                menuToOrderBeverage.Display,               
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray4, handlersArray4);

            ConsoleMenu menuToOrderFoodAndBeverage = new ConsoleMenu(itemsArray4);

            #endregion

            #region mainMenu

            MyXmlReader xmlMenu0 = new MyXmlReader(@"MenuInXmlFiles\mainMenu.xml");
            ArrayList itemsArray0 = xmlMenu0.ReadXmlMenuFileWithSpecificFormatAndReturnListOfMenuItems();

            Command commad = new Command();
            commad.MenuHandler = AdministratorAddAndShowMenu.Display;

            MenuFunctionHandler[] handlersArray = new MenuFunctionHandler[] { 
                menuToOrderFoodAndBeverage.Display,
                menuToOrderFoodAndBeverage.Display, //corect handler
                commad.ShowAdministratorMenu ,
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray0, handlersArray);
            ConsoleMenu mainMenu = new ConsoleMenu(itemsArray0);

            mainMenu.Display();

            #endregion

        }


    }
}
