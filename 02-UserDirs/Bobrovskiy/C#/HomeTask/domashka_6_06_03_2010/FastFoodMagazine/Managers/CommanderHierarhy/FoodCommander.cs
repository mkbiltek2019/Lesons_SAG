using System.Collections;
using Helpers.ConsoleMenu;

namespace FastFoodMagazine.Managers.CommanderHierarhy
{
    public class FoodCommander : Commander
    {
        #region Order manipulation for Food

        private ArrayList SearchForFoodByName(string productName)
        {
            return SearchForFoodByNameBase(productName, productWarehouse.FoodList);
        }
        
        public MenuResult OrderFoodByName(string foodName)
        {
            return DisplaySubMenu(SearchForFoodByName(foodName));
        }

        #endregion
    }
}
