using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Helpers.MyFood;
using Helpers.MyBeverage;

namespace Helpers.MyProduct
{
    class ProductWarehouse
    {
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

        public void ConsoleShowFoodList()
        {
            System.Console.WriteLine("\n");
            System.Console.WriteLine("┌───────────────────────────────────────────────────────────────────┐");
            foreach (Food obj in FoodList)
            {
                System.Console.WriteLine("│{0}│ \t{1}грн. │\t{2} гр. │", obj.Name, obj.Price, obj.Weight);
            }
            System.Console.WriteLine("└───────────────────────────────────────────────────────────────────┘");
            System.Console.WriteLine("\n");
        }

        public void ConsoleShowBeverageList()
        {
            System.Console.WriteLine("\n");
            System.Console.WriteLine("┌───────────────────────────────────────────────────────────────────┐");
            foreach (Beverage obj in BeverageList)
            {
                System.Console.WriteLine("│{0}│ \t{1}грн. │\t{2} мл. │", obj.Name, obj.Price, obj.Capacity);
            }
            System.Console.WriteLine("└───────────────────────────────────────────────────────────────────┘");
            System.Console.WriteLine("\n");
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
    }
}
