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
            #region Create product Warehouse			
			
			MyXmlReader beverage = new MyXmlReader(@"MenuInXmlFiles\Beverage.xml");
			MyXmlReader food = new MyXmlReader(@"MenuInXmlFiles\Food.xml");

			ProductWarehouse warehouse = new ProductWarehouse(
            food.ReadProductListFromXmlFileWithSpecificFormatAndReturnItLikeArray(Products.Food),
            beverage.ReadProductListFromXmlFileWithSpecificFormatAndReturnItLikeArray(Products.Beverage));
			
			#endregion

            #region Create menu commander

            Command menuCommander = new Command();
            menuCommander.InitializeWarehouse(warehouse);           

            #endregion

            #region AdministratorAddAndShowMenu

            MyXmlReader xmlMenu1 = new MyXmlReader(@"MenuInXmlFiles\AdministratorAddAndShowMenu.xml");
            ArrayList itemsArray1 = xmlMenu1.ReadXmlMenuFileWithSpecificFormatAndReturnListOfMenuItems();
		           
            MenuFunctionHandler[] handlersArray1 = new MenuFunctionHandler[] { 
                menuCommander.ViewFoodList,//show food list
                menuCommander.ViewBeverageList,//show beverage list
                menuCommander.AddToFood,//add to food 
                menuCommander.AddToBeverage,//add to beverage
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray1, handlersArray1);
            ConsoleMenu AdministratorAddAndShowMenu = new ConsoleMenu(itemsArray1);
           
            #endregion

            #region menuToOrderFood

            MyXmlReader xmlMenu3 = new MyXmlReader(@"MenuInXmlFiles\menuToOrderFood.xml");
            ArrayList itemsArray3 = xmlMenu3.ReadXmlMenuFileWithSpecificFormatAndReturnListOfMenuItems();            
			
            MenuFunctionHandler[] handlersArray3 = new MenuFunctionHandler[] { 
                menuCommander.OrderHotDog,
                menuCommander.OrderHamburger,
                menuCommander.OrderCheesburger,
                menuCommander.OrderFriedPotato,
                menuCommander.OrderBakery,                
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray3, handlersArray3);
            ConsoleMenu menuToOrderFood = new ConsoleMenu(itemsArray3);

            #endregion

            #region menuToOrderBeverage

            MyXmlReader xmlMenu2 = new MyXmlReader(@"MenuInXmlFiles\menuToOrderBeverage.xml");
            ArrayList itemsArray2 = xmlMenu2.ReadXmlMenuFileWithSpecificFormatAndReturnListOfMenuItems();			
			
            MenuFunctionHandler[] handlersArray2 = new MenuFunctionHandler[] { 
                menuCommander.OrderCoffee,
                menuCommander.OrderTea,
                menuCommander.OrderCocaCola,
                menuCommander.OrderShake,
                menuCommander.OrderMineralWater,                
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
            menuCommander.MenuHandler = AdministratorAddAndShowMenu.Display;

            MenuFunctionHandler[] handlersArray = new MenuFunctionHandler[] { 
                menuToOrderFoodAndBeverage.Display, //order food and beverage
                menuCommander.ShowOrder, //show Order
                menuCommander.ShowAdministratorMenu , // authentificate and go to admin menu
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray0, handlersArray);
            ConsoleMenu mainMenu = new ConsoleMenu(itemsArray0);

            mainMenu.Display();

            #endregion

        }


    }
}
