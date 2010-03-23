using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpers.MyProduct;

namespace Helpers.MyFood
{
   public class Food : Product
    {
        public string Weight
        {
            get;
            set;
        }

        public Food()
            : this(string.Empty, string.Empty, string.Empty)
        {
        }

        public Food(string name, string price, string weight)
            : base(name, price)
        {
            Weight = weight;
        }
    }
}
