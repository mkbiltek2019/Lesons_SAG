using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mcdonalds
{
    interface Product
    {
         string Name { get; set; }
         int Quantity { get; set; }
         int Price { get; set; }
    }
}
