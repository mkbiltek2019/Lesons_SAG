
using System;
using FastFoodMagazine.Managers.WareHouse;
using Helpers.ConsoleMenu;

namespace FastFoodMagazine.Managers.CommanderHierarhy
{
    public class WarehouseCommander: Commander
    {
        #region Warehouse manipulation

        public void InitializeWarehouse(ProductWarehouse warehouse)
        {
            productWarehouse = warehouse;
        }

        public MenuResult ViewFoodList(string s)
        {
            Console.Clear();
            productWarehouse.ConsoleShowFoodList();
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult ViewBeverageList(string s)
        {
            Console.Clear();
            productWarehouse.ConsoleShowBeverageList();
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult AddToFood(string s)
        {
            Console.Clear();
            productWarehouse.AddProductToFood(ConsoleSafeInput.FoodData());
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult AddToBeverage(string s)
        {
            Console.Clear();
            productWarehouse.AddProductToBeverage(ConsoleSafeInput.BeverageData());
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        #endregion
    }
}
