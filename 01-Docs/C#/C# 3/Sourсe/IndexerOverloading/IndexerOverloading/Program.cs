using System;
using System.Collections;

namespace IndexerOverloading
{

    public class Laptop
    {
        private string vendor;
        private double price;


        public string Vendor
        {
            get { return vendor; }
            set { vendor = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }

        }
        public Laptop(string v, double p)
        {
            vendor = v;
            price = p;
        }

        public override string ToString()
        {
            return vendor + " " + price.ToString();
        }
    }

    public class Shop : IEnumerable
    {
        private Laptop[] LaptopArr;

        public Shop(int size)
        {
            LaptopArr = new Laptop[size];
        }


        public int Length
        {
            get { return LaptopArr.Length; }
        }

        public Laptop this[int pos]
        {
            get
            {
                if (pos >= LaptopArr.Length || pos < 0)
                    throw new IndexOutOfRangeException();
                else
                    return (Laptop)LaptopArr[pos];
            }
            set
            {
                LaptopArr[pos] = (Laptop)value;
            }
        }

        private int Find(string name)
        {
            for (int i = 0; i < LaptopArr.Length; i++)
                if (LaptopArr[i].Vendor == name)
                    return i;
            return -1;
        }

        public Laptop this[string name]
        {
            get
            {
                if (name.Length == 0)
                    //return null;
                    throw new System.Exception("Недопустимый индекс");
                return this[Find(name)];
            }
        }

        public int FindByPrice(double price)
        {
            for (int i = 0; i < LaptopArr.Length; i++)
                if (LaptopArr[i].Price == price)
                    return i;
            return -1;
        }

        public Laptop this[double price]
        {
            get
            {
                if (price == 0)
                    throw new System.Exception("Недопустимый индекс");
                return this[FindByPrice(price)];
            }
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return LaptopArr.GetEnumerator();
        }

        #endregion
    }
    public class Tester
    {
        public static void Main()
        {
            Shop sh = new Shop(3);

            sh[0] = new Laptop("Samsung", 5200);
            sh[1] = new Laptop("Asus", 4700);
            sh[2] = new Laptop("LG", 4300);


            try
            {
                foreach (Laptop lt in sh)
                    Console.WriteLine(lt.ToString());
                Console.WriteLine();
                Console.WriteLine(sh["LG"]);
                Console.WriteLine();
                Console.WriteLine(sh[4700.0]);

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}

