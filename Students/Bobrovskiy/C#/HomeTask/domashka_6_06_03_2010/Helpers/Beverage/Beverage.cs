using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpers.MyProduct;

namespace Helpers.MyBeverage
{
    class Beverage : Product
    {
        public string Capacity
        {
            get;
            set;
        }

        public Beverage()
            : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public Beverage(string name, string price, string produceTime, string capacity)
            : base(name, price, produceTime)
        {
            Capacity = capacity;
        }
    }
}
