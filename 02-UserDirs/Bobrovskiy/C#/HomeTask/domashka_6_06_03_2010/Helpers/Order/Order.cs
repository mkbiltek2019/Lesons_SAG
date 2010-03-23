using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Helpers.MyProduct;

namespace Helpers.MyOrder
{
    public class Order
    {
        public ArrayList ProductList
        {
            get;
            private set;
        }
		
		public Order()
		{
			ProductList = new ArrayList();
		}

        public double OrderPrice
        {
            get;
            private set;
        }

        public void AddProductToOrder(Product product)
        {
            ProductList.Add(product);
        }

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
            //---------------------------------------31-------------------14-------------
            System.Console.WriteLine("┌───────────────────────────────┬──────────────┐");
            System.Console.WriteLine(@"│          Назва продукту       │   Цiна       │");
            System.Console.WriteLine("├───────────────────────────────┼──────────────┤");
        }

        private void PrintTableBottomLine()
        {
            //---------------------------------------31-------------------14------------
            System.Console.WriteLine("└───────────────────────────────┴──────────────┘");
        }

        public void ShowOrder()
        {
            PrintTableHeader();
            foreach (Product obj in ProductList)
            {
                System.Console.WriteLine("│{0}│{1}грн.│", SetWordLength(obj.Name,31), SetWordLength(obj.Price,10));
                OrderPrice += double.Parse(obj.Price);
            }
            PrintTableBottomLine();
            System.Console.WriteLine("\nВартiсть замовлення: {0}", OrderPrice);
            System.Console.WriteLine("\n");
        }
    }
}
