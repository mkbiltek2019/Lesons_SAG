
namespace FastFoodMagazine.MyProduct
{
    public enum Products { Food = 1, Beverage = 2 };

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

        public Product(string name, string price)
        {
            Name = name;
            Price = price;
        }

        public Product()
            : this(string.Empty, string.Empty)
        {
        }

    }
}