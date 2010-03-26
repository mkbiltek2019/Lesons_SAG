using System.Collections;
using FastFoodMagazine.MyProduct;
using FastFoodMagazine.MyProduct.MyBeverage;
using Helpers.ConsoleMenu;

namespace FastFoodMagazine.Managers.CommanderHierarhy
{
    public class BeverageCommander : Commander
    {
        #region Order manipulation for Beverage

        private ArrayList SearchForBeverageByName(string productName)
        {
            return SearchForFoodByNameBase(productName, productWarehouse.BeverageList);
        }

        public MenuResult OrderBeverageByName(string foodName)
        {
            return DisplaySubMenu(SearchForBeverageByName(foodName));
        }

        #endregion
    }
}
