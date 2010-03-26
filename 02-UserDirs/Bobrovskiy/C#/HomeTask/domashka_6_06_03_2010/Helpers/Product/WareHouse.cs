using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Helpers.MyFood;
using Helpers.MyBeverage;

namespace Helpers.MyProduct
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

        public string SetWordLength(string word, int length)
        {
            string result = word;
            if (word.Length > length)
            {
                result = word.Remove(length);
            }
            if (word.Length < length)
            {
                StringBuilder str = new StringBuilder(result);
                while (str.Length < length)
                {
                    str.Append(" ");
                }
                result = str.ToString();
            }
            if (word.Length == length)
            {
                result = word;
            }
            return result;
        }

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
                foreach (Food ob in FoodList)
                {
                    System.Console.WriteLine("│{0}│{1}грн.│{2}гр.│",
                        SetWordLength(ob.Name, 28),
                        SetWordLength(ob.Price, 10),
                        SetWordLength(ob.Weight, 12));
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
                foreach (Beverage obj in BeverageList)
                {
                    System.Console.WriteLine("│{0}│{1}грн.│{2}мл.│",
                        SetWordLength(obj.Name, 28),
                        SetWordLength(obj.Price, 10),
                        SetWordLength(obj.Capacity, 12));
                }
                PrintTableBottomLine();
                System.Console.WriteLine("\n");
            }
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
