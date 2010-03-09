using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Helpers.Order
{
    public class Order
    {
        public double OrderPrice
        {
            get;
            set;
        }

        private ArrayList ProductList = new ArrayList();

        public Order(ArrayList productList)
        {
            OrderPrice = 0.00;
            ProductList = productList;
        }

        public void ShowOrder()
        {
            foreach (var obj in ProductList)
            {
               System.Console.WriteLine(obj.ToString());
            }
        }
    }
}
