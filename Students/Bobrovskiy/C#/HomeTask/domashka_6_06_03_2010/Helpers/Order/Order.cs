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

        public double OrderPrice
        {
            get;
            private set;
        }

        public void AddProductToOrder(Product product)
        {
            ProductList.Add(product);
        }

        public void ShowOrder()
        {
            System.Console.WriteLine("\n");
            System.Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
            foreach (Product obj in ProductList)
            {
                System.Console.WriteLine("│ {0} │ \t{1}грн. │", obj.Name, obj.Price);
            }
            System.Console.WriteLine("└──────────────────────────────────────────────────────────────┘");
            System.Console.WriteLine("\nTotal Order Price: {0}", OrderPrice);
            System.Console.WriteLine("\n");
        }
    }
}
