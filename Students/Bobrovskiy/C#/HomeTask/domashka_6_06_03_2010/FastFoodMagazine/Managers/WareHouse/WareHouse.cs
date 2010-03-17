using System.Collections;
using FastFoodMagazine.MyProduct.MyBeverage;
using FastFoodMagazine.MyProduct.Food;

namespace FastFoodMagazine.Managers.WareHouse
{
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

        private void PrintTableHeader()
        {
            //---------------------------------------28-------------------14-------------14---
            System.Console.WriteLine("┌────────────────────────────┬──────────────┬───────────────┐");
            System.Console.WriteLine(@"│        Назва продукту      │   Цiна       │  Вага (об'єм) │");
            System.Console.WriteLine("├────────────────────────────┼──────────────┼───────────────┤");
        }

        private void PrintTableBottomLine()
        {
            //---------------------------------------28-------------------14-------------14---
            System.Console.WriteLine("└────────────────────────────┴──────────────┴───────────────┘");
        }

        public void ConsoleShowFoodList()
        {
            if (FoodList.Count > 0)
            {
                PrintTableHeader();
                const string format = "│{0,-28:G}│{1,-10:G}грн.│{2,-12:G}гр.│";
                foreach (Food ob in FoodList)
                {
                    System.Console.WriteLine(format, ob.Name, ob.Price, ob.Weight);
                }
                PrintTableBottomLine();
                System.Console.WriteLine("\n");
            }
        }

        public void ConsoleShowBeverageList()
        {
            if (BeverageList.Count > 0)
            {
                PrintTableHeader();
                const string format = "│{0,-28:G}│{1,-10:G}грн.│{2,-12:G}мл.│";
                foreach (Beverage obj in BeverageList)
                {
                    System.Console.WriteLine(format, obj.Name, obj.Price, obj.Capacity);
                }
                PrintTableBottomLine();
                System.Console.WriteLine("\n");
            }
        }

        public void AddProductToFood(MyProduct.Product product)
        {
            FoodList.Add(product);
            Changed = true;
        }

        public void AddProductToBeverage(MyProduct.Product product)
        {
            BeverageList.Add(product);
            Changed = true;
        }

        #endregion
    }
}