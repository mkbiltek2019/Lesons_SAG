using System.Collections;
using FastFoodMagazine.MyProduct;
using Helpers.ConsoleMenu;

namespace FastFoodMagazine.Managers.CommanderHierarhy
{
    public class FoodCommander : Commander
    {
        #region Order manipulation for Food

        private ConsoleMenu subMenu;

        private MenuResult GetProductAndAddToOrder()
        {
            Product prod = new Product(subMenu.SelectedMenuItem.Key, subMenu.SelectedMenuItem.Description);
            currentOrder.AddProductToOrder(prod);
            return MenuResult.Proceed;
        }

        private ArrayList SearchForFoodByName(string productName)
        {
            ArrayList temp = new ArrayList();

            for (int i = 0; i < productWarehouse.FoodList.Count; i++)
            {
                if (((Product)productWarehouse.FoodList[i]).Name.Substring(0, productName.Length) == (productName))
                {
                    ConsoleMenuItem item = new ConsoleMenuItem(((Product)productWarehouse.FoodList[i]).Price,
                                                               ((Product)productWarehouse.FoodList[i]).Name,
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

        public MenuResult OrderHotDog()
        {
            ArrayList temp = SearchForFoodByName(@"Хот");
            subMenu = new ConsoleMenu(temp);
            subMenu.Display();
            return MenuResult.Proceed;
        }

        public MenuResult OrderHamburger()
        {
            ArrayList temp = SearchForFoodByName(@"Гамб");
            subMenu = new ConsoleMenu(temp);
            subMenu.Display();
            return MenuResult.Proceed;
        }

        public MenuResult OrderCheesburger()
        {
            ArrayList temp = SearchForFoodByName(@"Чiзб");
            subMenu = new ConsoleMenu(temp);
            subMenu.Display();
            return MenuResult.Proceed;
        }

        public MenuResult OrderFriedPotato()
        {
            ArrayList temp = SearchForFoodByName(@"Карт");
            subMenu = new ConsoleMenu(temp);
            subMenu.Display();
            return MenuResult.Proceed;
        }

        public MenuResult OrderBakery()
        {
            ArrayList temp = SearchForFoodByName(@"Було");
            subMenu = new ConsoleMenu(temp);
            subMenu.Display();
            return MenuResult.Proceed;
        }

        #endregion
    }
}
