
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

        public string Volume
        {
            get;
            set;
        }

        public Product(string name, string price, string volume)
        {
            Name = name;
            Price = price;
            Volume = volume;
        }

        public Product()
            : this(string.Empty, string.Empty, string.Empty)
        {
        }

    }
}