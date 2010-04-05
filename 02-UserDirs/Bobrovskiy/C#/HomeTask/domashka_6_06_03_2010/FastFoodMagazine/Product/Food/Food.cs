
namespace FastFoodMagazine.MyProduct.Food
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
            : base(name, price, weight)
        {
            Weight = weight;
        }
    }
}