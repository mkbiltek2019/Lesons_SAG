using System.Collections;
using FastFoodMagazine.MyProduct;
using FastFoodMagazine.MyProduct.MyBeverage;
using Helpers.ConsoleMenu;

namespace FastFoodMagazine.Managers.CommanderHierarhy
{
    public class BeverageCommander : Commander
    {
        #region Order manipulation for Beverage

        private ConsoleMenu subMenu;

        private MenuResult GetProductAndAddToOrder()
        {
            Product prod = new Product(subMenu.SelectedMenuItem.Key, subMenu.SelectedMenuItem.Description);
            currentOrder.AddProductToOrder(prod);
            return MenuResult.Proceed;
        }

        private ArrayList SearchForBeverageByName(string productName)
        {
            ArrayList temp = new ArrayList();

            for (int i = 0; i < productWarehouse.BeverageList.Count; i++)
            {
                if (((Product)productWarehouse.BeverageList[i]).Name.Substring(0, productName.Length) == (productName))
                {
                    ConsoleMenuItem item = new ConsoleMenuItem(((Product)productWarehouse.BeverageList[i]).Price,
                                                               ((Product)productWarehouse.BeverageList[i]).Name,
                                                               true, GetProductAndAddToOrder);
                    temp.Add(item);
                }
            }

            ConsoleMenuItem exit = new ConsoleMenuItem(" ",
                                                       "Повернутись до попереднього меню", true,
                                                       delegate() { return MenuResult.Exit; });

            temp.Add(exit);

            return temp;
        }

        public MenuResult OrderTea()
        {
            ArrayList temp = SearchForBeverageByName("Чай");
            subMenu = new ConsoleMenu(temp);
            subMenu.Display();
            return MenuResult.Proceed;
        }

        public MenuResult OrderCoffee()
        {
            ArrayList temp = SearchForBeverageByName("Кава");
            subMenu = new ConsoleMenu(temp);
            subMenu.Display();
            return MenuResult.Proceed;
        }

        public MenuResult OrderCocaCola()
        {
            ArrayList temp = SearchForBeverageByName("Кока");
            subMenu = new ConsoleMenu(temp);
            subMenu.Display();
            return MenuResult.Proceed;
        }

        public MenuResult OrderSheik()
        {
            ArrayList temp = SearchForBeverageByName("Шейк");
            subMenu = new ConsoleMenu(temp);
            subMenu.Display();
            return MenuResult.Proceed;
        }

        public MenuResult OrderWater()
        {
            ArrayList temp = SearchForBeverageByName("Вода");
            subMenu = new ConsoleMenu(temp);
            subMenu.Display();
            return MenuResult.Proceed;
        }

        #endregion
    }
}
