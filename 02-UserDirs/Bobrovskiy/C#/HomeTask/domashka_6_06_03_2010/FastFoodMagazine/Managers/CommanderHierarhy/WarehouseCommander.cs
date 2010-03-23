
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

        public MenuResult ViewFoodList()
        {
            Console.Clear();
            productWarehouse.ConsoleShowFoodList();
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult ViewBeverageList()
        {
            Console.Clear();
            productWarehouse.ConsoleShowBeverageList();
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult AddToFood()
        {
            Console.Clear();
            productWarehouse.AddProductToFood(ConsoleSafeInput.FoodData());
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult AddToBeverage()
        {
            Console.Clear();
            productWarehouse.AddProductToBeverage(ConsoleSafeInput.BeverageData());
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        #endregion
    }
}
