using System;
using FastFoodMagazine.Managers.WareHouse;
using FastFoodMagazine.Product.Beverage;
using FastFoodMagazine.Product.Food;
using Helpers.ConsoleMenu;

namespace FastFoodMagazine.Managers.Commander
{
    public static class ConsoleSafeInput
    {
        public static int ReadIntegerNumber()
        {
            int result = 0;
            const int defaultValue = 0; // used to return normal value in case of some input error
            const string errorMessage = "Bad input!!!!!!";
            try
            {
                result = int.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException )
            {
                Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            catch (FormatException )
            {
                Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            catch (OverflowException )
            {
                Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            return result;
        }

        public static double ReadDoubleNumber()
        {
            double result = 0;
            const double defaultValue = 0; // used to return normal value in case of some input error
            const string errorMessage = "Bad input!!!!!!";
            try
            {
                result = double.Parse(Console.ReadLine());
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            catch (FormatException)
            {
                Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            catch (OverflowException)
            {
                Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            return result;
        }

        public static void LoginAndPasswd(ref string curentLogin, ref string currentPasswd)
        {
            Console.Clear();
            Console.WriteLine("Please input authentification data.\n");
            Console.Write("Input Login: ");
            curentLogin = Console.ReadLine();
            Console.Write("Input passwd: ");
            currentPasswd = Console.ReadLine();
        }

        public static Food FoodData()
        {
            Console.Clear();
            Console.Write("Input food name: ");
            string name = Console.ReadLine();
            Console.Write("Input food price: ");
            string price = Console.ReadLine();
            Console.Write("Input food volume (in gram): ");
            string volume = Console.ReadLine();

            return new Food(name, price, volume);
        }

        public static Beverage BeverageData()
        {
            string name = string.Empty;
            string price = string.Empty;
            string volume = string.Empty;

            Console.Clear();
            Console.Write("Input food name: ");
            name = Console.ReadLine();
            Console.Write("Input food price: ");
            price = Console.ReadLine();
            Console.Write("Input food capacity (in millilitre): ");
            volume = Console.ReadLine();

            return new Beverage(name, price, volume);
        }
    }

    public class Commander
    {
        private const string Passwd = "qwerty";
        private const string Name = "admin";
        private string curentLogin = string.Empty;
        private string currentPasswd = string.Empty;
        private ProductWarehouse productWarehouse = new ProductWarehouse();
        private Order.Order currentOrder = new Order.Order();

        #region Properties description

        public MenuFunctionHandler MenuHandler
        {
            get;
            set;
        }

        public bool AuthentificationSuccessful
        {
            get;
            private set;
        }

        #endregion

        #region AdministratorMenu manipulation

        private void LoginPasswordCheck()
        {
            AuthentificationSuccessful = false;
            ConsoleSafeInput.LoginAndPasswd(ref curentLogin, ref currentPasswd);
            if ((curentLogin.Equals(Name)) && (currentPasswd.Equals(Passwd)))
            {
                AuthentificationSuccessful = true;
            }
        }

        public MenuResult ShowAdministratorMenu()
        {
            LoginPasswordCheck();
            if (AuthentificationSuccessful)
            {
                return MenuHandler.Invoke();
            }
            else
            {
                return MenuResult.Proceed;
            }
        }

        #endregion

        #region Warehouse manipulation

        public void InitializeWarehouse(ProductWarehouse warehouse)
        {
            productWarehouse = warehouse;
        }

        public MenuResult ViewFoodList()
        {
            Console.Clear();
            productWarehouse.ConsoleShowFoodList();
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult ViewBeverageList()
        {
            Console.Clear();
            productWarehouse.ConsoleShowBeverageList();
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult AddToFood()
        {
            Console.Clear();
            productWarehouse.AddProductToFood(ConsoleSafeInput.FoodData());
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult AddToBeverage()
        {
            Console.Clear();
            productWarehouse.AddProductToBeverage(ConsoleSafeInput.BeverageData());
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        #endregion

        #region Order manipulation for Food

        private int SearchForProductByName(string productName)
        {
            for (int i = 0; i < productWarehouse.FoodList.Count; i++)
            {
                if (((Food)productWarehouse.FoodList[i]).Name.Equals(productName))
                {
                    return i;
                }
            }
            return -1;
        }

        public MenuResult OrderHotDog()
        {
            int index = SearchForProductByName("Хот дог");
            if ((index >= 0) && (index <= productWarehouse.FoodList.Count))
            {
                currentOrder.AddProductToOrder((Product.Product)productWarehouse.FoodList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderHamburger()
        {
            int index = SearchForProductByName("Гамбургер");
            if ((index >= 0) && (index <= productWarehouse.FoodList.Count))
            {
                currentOrder.AddProductToOrder((Product.Product)productWarehouse.FoodList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderCheesburger()
        {
            int index = SearchForProductByName("Чiзбургер");
            if ((index >= 0) && (index <= productWarehouse.FoodList.Count))
            {
                currentOrder.AddProductToOrder((Product.Product)productWarehouse.FoodList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderFriedPotato()
        {
            int index = SearchForProductByName("Картопля Фрi");
            if ((index >= 0) && (index <= productWarehouse.FoodList.Count))
            {
                currentOrder.AddProductToOrder((Product.Product)productWarehouse.FoodList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderBakery()
        {
            int index = SearchForProductByName("Пончик");
            if ((index >= 0) && (index <= productWarehouse.FoodList.Count))
            {
                currentOrder.AddProductToOrder((Product.Product)productWarehouse.FoodList[index]);
            }

            return MenuResult.Proceed;
        }

        #endregion

        #region Order manipulation for Beverage

        private int SearchForBeverageByName(string productName)
        {
            for (int i = 0; i < productWarehouse.BeverageList.Count; i++)
            {
                if (((Beverage)productWarehouse.BeverageList[i]).Name.Equals(productName))
                {
                    return i;
                }
            }
            return -1;
        }

        public MenuResult OrderCoffee()
        {
            int index = SearchForBeverageByName("Кава");
            if ((index >= 0) && (index <= productWarehouse.BeverageList.Count))
            {
                currentOrder.AddProductToOrder((Product.Product)productWarehouse.BeverageList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderCocaCola()
        {
            int index = SearchForBeverageByName("Кока кола");
            if ((index >= 0) && (index <= productWarehouse.BeverageList.Count))
            {
                currentOrder.AddProductToOrder((Product.Product)productWarehouse.BeverageList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderTea()
        {
            int index = SearchForBeverageByName("Чай зелений");
            if ((index >= 0) && (index <= productWarehouse.BeverageList.Count))
            {
                currentOrder.AddProductToOrder((Product.Product)productWarehouse.BeverageList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderShake()
        {
            int index = SearchForBeverageByName("Шейк");
            if ((index >= 0) && (index <= productWarehouse.BeverageList.Count))
            {
                currentOrder.AddProductToOrder((Product.Product)productWarehouse.BeverageList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderMineralWater()
        {
            int index = SearchForBeverageByName("Вода мiнеральна");
            if ((index >= 0) && (index <= productWarehouse.BeverageList.Count))
            {
                currentOrder.AddProductToOrder((Product.Product)productWarehouse.BeverageList[index]);
            }

            return MenuResult.Proceed;
        }

        #endregion

        #region Order manipulation

        public MenuResult ShowOrder()
        {
            Console.Clear();
            currentOrder.ShowOrder();
            Console.ReadKey();
            return MenuResult.Proceed;
        }

        #endregion

    }
}