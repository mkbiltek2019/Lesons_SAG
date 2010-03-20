using System;

using FastFoodMagazine.Managers.WareHouse;
using FastFoodMagazine.MyProduct.MyBeverage;
using FastFoodMagazine.MyProduct.Food;
using Helpers.ConsoleMenu;
using FastFoodMagazine.Managers.MyOrder;

namespace FastFoodMagazine.Managers.CommanderHierarhy
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
        protected const string Passwd = "qwerty";
        protected const string Name = "admin";
        protected string curentLogin = string.Empty;
        protected string currentPasswd = string.Empty;
        protected static ProductWarehouse productWarehouse = new ProductWarehouse();
        protected static Order currentOrder = new Order();

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