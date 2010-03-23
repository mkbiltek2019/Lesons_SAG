using System.Collections;

namespace FastFoodMagazine.Managers.MyOrder
{
    public class Order
    {
        public ArrayList ProductList
        {
            get;
            private set;
        }

        public Order()
        {
            ProductList = new ArrayList();
        }

        public double OrderPrice
        {
            get;
            private set;
        }

        public void AddProductToOrder(MyProduct.Product product)
        {
            ProductList.Add(product);
        }

        private void PrintTableHeader()
        {
            //---------------------------------------31-------------------14-------------
            System.Console.WriteLine("┌───────────────────────────────┬──────────────┐");
            System.Console.WriteLine(@"│          Назва продукту       │   Цiна       │");
            System.Console.WriteLine("├───────────────────────────────┼──────────────┤");
        }

        private void PrintTableBottomLine()
        {
            //---------------------------------------31-------------------14------------
            System.Console.WriteLine("└───────────────────────────────┴──────────────┘");
        }

        public void ShowOrder()
        {
            PrintTableHeader();
            OrderPrice = 0;
            const string format = "│{0,-31:G}│{1,-10:G}грн.│";
            foreach (MyProduct.Product obj in ProductList)
            {
                System.Console.WriteLine(format, obj.Name, obj.Price);
                OrderPrice += double.Parse(obj.Price);
            }
            PrintTableBottomLine();
            System.Console.WriteLine("\nВартiсть замовлення: {0}", OrderPrice);
            System.Console.WriteLine("\n");
        }
    }
}