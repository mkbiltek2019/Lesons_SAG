using System.Collections;
using FastFoodMagazine.MyProduct;

namespace FastFoodMagazine.Managers.WareHouse
{
    public static class ConsoleWarehousePrinter
    { 
        public static void PrintTableHeader()
        {
            //---------------------------------------28-------------------14-------------14---
            System.Console.WriteLine("┌────────────────────────────┬──────────────┬───────────────┐");
            System.Console.WriteLine(@"│        Назва продукту      │   Цiна       │  Вага (об'єм) │");
            System.Console.WriteLine("├────────────────────────────┼──────────────┼───────────────┤");
        }

        public static void PrintTableBottomLine()
        {
            //---------------------------------------28-------------------14-------------14---
            System.Console.WriteLine("└────────────────────────────┴──────────────┴───────────────┘");
        }

        public static void ConsoleShowFoodList(ArrayList productList)
        {
            if (productList.Count > 0)
            {
                PrintTableHeader();
                const string format = "│{0,-28:G}│{1,-10:G}грн.│{2,-12:G}│";
                foreach (Product ob in productList)
                {
                    System.Console.WriteLine(format, ob.Name, ob.Price, ob.Volume);
                }
                PrintTableBottomLine();
                System.Console.WriteLine("\n");
            }
        }
    }

    public class ProductWarehouse
    {
        #region ProductWarehouse properties

        public ArrayList FoodList
        {
            get;
            private set;
        }

        public ArrayList BeverageList
        {
            get;
            private set;
        }

        public bool Changed
        {
            get;
            set;
        }

        #endregion

        #region ProductWarehouse constructors

        public ProductWarehouse()
        {
            Changed = false;
            FoodList = new ArrayList();
            BeverageList = new ArrayList();
        }

        public ProductWarehouse(ArrayList food, ArrayList beverage)
        {
            Changed = false;
            FoodList = food;
            BeverageList = beverage;
        }

        #endregion

        #region ProductWarehouse methods

        public void ShowFoodList()
        {
           ConsoleWarehousePrinter.ConsoleShowFoodList(FoodList);
        }

        public void ShowBeverageList()
        {
           ConsoleWarehousePrinter.ConsoleShowFoodList(BeverageList);
        }

        public void AddProductToFood(Product product)
        {
            FoodList.Add(product);
            Changed = true;
        }

        public void AddProductToBeverage(Product product)
        {
            BeverageList.Add(product);
            Changed = true;
        }

        #endregion
    }
}