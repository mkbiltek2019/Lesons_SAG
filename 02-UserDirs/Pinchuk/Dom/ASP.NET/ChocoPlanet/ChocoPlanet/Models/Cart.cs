using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ChocoPlanet.Models
{
    public class Cart
    {
        private List<CartLine> lines = new List<CartLine>();
        public IList<CartLine> Lines { get { return lines.AsReadOnly(); } }

        private ShippingDetails shippingDetails=new ShippingDetails();
        public ShippingDetails ShippingDetails
        {
            get { return shippingDetails; }
        }

        public void AddItem(Product product, int quantity)
        {
            var line = lines.FirstOrDefault(l => l.Product.ID == product.ID);
            if (line == null)
                lines.Add(new CartLine() { Product = product, Quantity = quantity });
            else
            {
                line.Quantity += quantity;
            }


        }
        public decimal ComputerTotalValue()
        {
            return lines.Sum(l => l.Product.Price * l.Quantity);
        }
        public void Clear()
        {
            lines.Clear();
        }
        public void RemoteLine(Product product)
        {
            lines.RemoveAll(l => l.Product.ID == product.ID);
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}