using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpers.MyProduct
{
    public class Product
    {
        public string Name
        {
            get;
            set;
        }

        public string Price
        {
            get;
            set;
        }

        public string ProduceTime
        {
            get;
            set;
        }

        public Product(string name, string price, string produceTime)
        {
            Name = name;
            Price = price;
            ProduceTime = produceTime;
        }

        public Product()
            : this(string.Empty, string.Empty, string.Empty)
        { 
        }

    }
}
