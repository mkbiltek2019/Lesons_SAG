namespace FastFoodMagazine.MyProduct.MyBeverage
{
    public class Beverage : Product
    {
        public string Capacity
        {
            get;
            set;
        }

        public Beverage()
            : this(string.Empty, string.Empty, string.Empty)
        {
        }

        public Beverage(string name, string price, string capacity)
            : base(name, price, capacity)
        {
            Capacity = capacity;
        }
    }
}