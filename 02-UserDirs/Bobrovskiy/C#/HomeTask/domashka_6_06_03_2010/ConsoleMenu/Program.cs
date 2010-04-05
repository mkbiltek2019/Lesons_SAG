using System.Collections;
using FastFoodMagazine.Managers.CommanderHierarhy;
using FastFoodMagazine.Managers.WareHouse;
using FastFoodMagazine.XmlReader;

using Helpers.ConsoleMenu;

namespace ConsoleMenuSample
{
    class Program
    {
        private static void HandlersToMenuItemsBinding(IList itemsArray, MenuFunctionHandler[] handlersArray)
        {
            for (int i = 0; i < itemsArray.Count; i++)
            {
                ((ConsoleMenuItem)itemsArray[i]).Action = handlersArray[i];
            }
        }

        private static MenuResult MenuExit(string s)
        {
            System.Console.WriteLine("\n");
            System.Console.WriteLine("┌─────────────────────────────────────────────────────────┐");
            System.Console.WriteLine("│ Дякуємо ВАМ за вiдвiдування закладу швидкого харчування │");
            System.Console.WriteLine("│                    МАКДОНАЛЬДЗ                          │");
            System.Console.WriteLine("└─────────────────────────────────────────────────────────┘");
            System.Console.WriteLine("\n");
            return MenuResult.Exit;
        }

        static void Main()
        {
            string[] foodStaff = new string[] { @"Хот", @"Гамб", @"Чiзб", @"Карт", @"Було" };

            string[] beverageStuff = new string[] {@"Кава", @"Чай", @"Кока", @"Шейк", @"Вода" };

            #region Create product Warehouse

            MyXmlReader beverage = new MyXmlReader(@"MenuInXmlFiles\Beverage.xml");
            MyXmlReader food = new MyXmlReader(@"MenuInXmlFiles\Food.xml");

            ProductWarehouse warehouse = new ProductWarehouse(
            food.ReadProductData(),
            beverage.ReadProductData());

            #endregion

            #region Create menu commanders

            Commander menuCommander = new Commander();

            WarehouseCommander warehouseCommander = new WarehouseCommander();
            warehouseCommander.InitializeWarehouse(warehouse);
           
            BeverageCommander menuBeverageCommander = new BeverageCommander();

            FoodCommander menuFoodCommander = new FoodCommander();

            #endregion

            #region AdministratorAddAndShowMenu

            MyXmlReader xmlMenu1 = new MyXmlReader(@"MenuInXmlFiles\AdministratorAddAndShowMenu.xml");
            ArrayList itemsArray1 = xmlMenu1.ReadMenuData();

            MenuFunctionHandler[] handlersArray1 = new MenuFunctionHandler[] { 
                warehouseCommander.ViewFoodList,//show food list
                warehouseCommander.ViewBeverageList,//show beverage list
                warehouseCommander.AddToFood,//add to food 
                warehouseCommander.AddToBeverage,//add to beverage
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray1, handlersArray1);
            ConsoleMenu AdministratorAddAndShowMenu = new ConsoleMenu(itemsArray1);

            #endregion

            #region menuToOrderFood

            MyXmlReader xmlMenu3 = new MyXmlReader(@"MenuInXmlFiles\menuToOrderFood.xml");
            ArrayList itemsArray3 = xmlMenu3.ReadMenuData();

            MenuFunctionHandler[] handlersArray3 = new MenuFunctionHandler[] { 
                delegate(string s) { return menuFoodCommander.OrderFoodByName(foodStaff[0]); },
                delegate(string s) { return menuFoodCommander.OrderFoodByName(foodStaff[1]); },
                delegate(string s) { return menuFoodCommander.OrderFoodByName(foodStaff[2]); },
                delegate(string s) { return menuFoodCommander.OrderFoodByName(foodStaff[3]); },
                delegate(string s) { return menuFoodCommander.OrderFoodByName(foodStaff[4]); },                
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray3, handlersArray3);
            ConsoleMenu menuToOrderFood = new ConsoleMenu(itemsArray3);

            #endregion

            #region menuToOrderBeverage

            MyXmlReader xmlMenu2 = new MyXmlReader(@"MenuInXmlFiles\menuToOrderBeverage.xml");
            ArrayList itemsArray2 = xmlMenu2.ReadMenuData();

            MenuFunctionHandler[] handlersArray2 = new MenuFunctionHandler[] { 
                delegate(string s) { return menuBeverageCommander.OrderBeverageByName(beverageStuff[0]); }, 
                delegate(string s) { return menuBeverageCommander.OrderBeverageByName(beverageStuff[1]); },                
                delegate(string s) { return menuBeverageCommander.OrderBeverageByName(beverageStuff[2]); },                
                delegate(string s) { return menuBeverageCommander.OrderBeverageByName(beverageStuff[3]); },                
                delegate(string s) { return menuBeverageCommander.OrderBeverageByName(beverageStuff[4]); },
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray2, handlersArray2);
            ConsoleMenu menuToOrderBeverage = new ConsoleMenu(itemsArray2);

            #endregion

            #region menuToOrderFoodAndBeverage

            MyXmlReader xmlMenu4 = new MyXmlReader(@"MenuInXmlFiles\menuToOdrerFoodAndBeverage.xml");
            ArrayList itemsArray4 = xmlMenu4.ReadMenuData();

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
            ArrayList itemsArray0 = xmlMenu0.ReadMenuData();
            menuCommander.MenuHandler = AdministratorAddAndShowMenu.Display;

            MenuFunctionHandler[] handlersArray = new MenuFunctionHandler[] { 
                menuToOrderFoodAndBeverage.Display, //order food and beverage
                menuCommander.ViewOrder, //show Order
                menuCommander.AdministratorMenuAuthentification , // authentificate and go to admin menu
                MenuExit
            };

            HandlersToMenuItemsBinding(itemsArray0, handlersArray);
            ConsoleMenu mainMenu = new ConsoleMenu(itemsArray0);

            mainMenu.Display(string.Empty);

            #endregion
        }
    }
}
