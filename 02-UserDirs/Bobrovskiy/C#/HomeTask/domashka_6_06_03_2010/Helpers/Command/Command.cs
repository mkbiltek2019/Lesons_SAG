using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Helpers.Console;
using Helpers.MyFood;
using Helpers.MyBeverage;
using Helpers.MyProduct;
using Helpers.MyOrder;

namespace Helpers.MyCommand
{
    public static class ConsoleSafeInput
    {
        public static int ReadIntegerNumber()
        {
            string inputString = System.Console.ReadLine();
            int result = 0;
            int defaultValue = 0; // used to return normal value in case of some input error
            string errorMessage = "Bad input!!!!!!";
            try
            {
                result = int.Parse(inputString);
            }
            catch (ArgumentNullException e)
            {
                System.Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            catch (FormatException e)
            {
                System.Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            catch (OverflowException e)
            {
                System.Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            return result;
        }

        public static double ReadDoubleNumber()
        {
            string inputString = System.Console.ReadLine();
            double result = 0;
            double defaultValue = 0; // used to return normal value in case of some input error
            string errorMessage = "Bad input!!!!!!";
            try
            {
                result = double.Parse(inputString);
            }
            catch (ArgumentNullException e)
            {
                System.Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            catch (FormatException e)
            {
                System.Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            catch (OverflowException e)
            {
                System.Console.WriteLine(errorMessage);
                result = defaultValue;
            }
            return result;
        }

        public static void LoginAndPasswd(ref string curentLogin, ref string currentPasswd)
        {
            System.Console.Clear();
            System.Console.WriteLine("Please input authentification data.\n");
            System.Console.Write("Input Login: ");
            curentLogin = System.Console.ReadLine();
            System.Console.Write("Input passwd: ");
            currentPasswd = System.Console.ReadLine();
        }

        public static Food FoodData()
        {
            string name = string.Empty;
            string price = string.Empty;
            string volume = string.Empty;

            System.Console.Clear();
            System.Console.Write("Input food name: ");
            name = System.Console.ReadLine();
            System.Console.Write("Input food price: ");
            price = System.Console.ReadLine();
            System.Console.Write("Input food volume (in gram): ");
            volume = System.Console.ReadLine();

            return new Food(name, price, volume);
        }

        public static Beverage BeverageData()
        {
            string name = string.Empty;
            string price = string.Empty;
            string volume = string.Empty;

            System.Console.Clear();
            System.Console.Write("Input food name: ");
            name = System.Console.ReadLine();
            System.Console.Write("Input food price: ");
            price = System.Console.ReadLine();
            System.Console.Write("Input food capacity (in millilitre): ");
            volume = System.Console.ReadLine();

            return new Beverage(name, price, volume);
        }
    }

    public class Command
    {
        private const string passwd = "qwerty";
        private const string name = "admin";
        private string curentLogin = string.Empty;
        private string currentPasswd = string.Empty;
        private ProductWarehouse productWarehouse = new ProductWarehouse();
        private Order currentOrder = new Order();

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
            if ((curentLogin.Equals(name)) && (currentPasswd.Equals(passwd)))
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
            System.Console.Clear();
            productWarehouse.ConsoleShowFoodList();
            System.Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult ViewBeverageList()
        {
            System.Console.Clear();
            productWarehouse.ConsoleShowBeverageList();
            System.Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult AddToFood()
        {
            System.Console.Clear();
            productWarehouse.AddProductToFood(ConsoleSafeInput.FoodData());
            System.Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult AddToBeverage()
        {
            System.Console.Clear();
            productWarehouse.AddProductToBeverage(ConsoleSafeInput.BeverageData());
            System.Console.ReadKey();
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
                currentOrder.AddProductToOrder((Product)productWarehouse.FoodList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderHamburger()
        {
            int index = SearchForProductByName("Гамбургер");
            if ((index >= 0) && (index <= productWarehouse.FoodList.Count))
            {
                currentOrder.AddProductToOrder((Product)productWarehouse.FoodList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderCheesburger()
        {
            int index = SearchForProductByName("Чiзбургер");
            if ((index >= 0) && (index <= productWarehouse.FoodList.Count))
            {
                currentOrder.AddProductToOrder((Product)productWarehouse.FoodList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderFriedPotato()
        {
            int index = SearchForProductByName("Картопля Фрi");
            if ((index >= 0) && (index <= productWarehouse.FoodList.Count))
            {
                currentOrder.AddProductToOrder((Product)productWarehouse.FoodList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderBakery()
        {
            int index = SearchForProductByName("Пончик");
            if ((index >= 0) && (index <= productWarehouse.FoodList.Count))
            {
                currentOrder.AddProductToOrder((Product)productWarehouse.FoodList[index]);
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
                currentOrder.AddProductToOrder((Product)productWarehouse.BeverageList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderCocaCola()
        {
            int index = SearchForBeverageByName("Кока кола");
            if ((index >= 0) && (index <= productWarehouse.BeverageList.Count))
            {
                currentOrder.AddProductToOrder((Product)productWarehouse.BeverageList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderTea()
        {
            int index = SearchForBeverageByName("Чай зелений");
            if ((index >= 0) && (index <= productWarehouse.BeverageList.Count))
            {
                currentOrder.AddProductToOrder((Product)productWarehouse.BeverageList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderShake()
        {
            int index = SearchForBeverageByName("Шейк");
            if ((index >= 0) && (index <= productWarehouse.BeverageList.Count))
            {
                currentOrder.AddProductToOrder((Product)productWarehouse.BeverageList[index]);
            }

            return MenuResult.Proceed;
        }

        public MenuResult OrderMineralWater()
        {
            int index = SearchForBeverageByName("Вода мiнеральна");
            if ((index >= 0) && (index <= productWarehouse.BeverageList.Count))
            {
                currentOrder.AddProductToOrder((Product)productWarehouse.BeverageList[index]);
            }

            return MenuResult.Proceed;
        }

        #endregion

        #region Order show

        public MenuResult ShowOrder()
        {
            System.Console.Clear();
            currentOrder.ShowOrder();
            System.Console.ReadKey();
            return MenuResult.Proceed;
        }

        #endregion

    }
}
