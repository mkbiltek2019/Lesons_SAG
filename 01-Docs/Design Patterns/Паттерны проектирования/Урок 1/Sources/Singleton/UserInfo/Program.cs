using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string login;
            string password = "";
            Console.Write("Login: ");
            login = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();
            /* 
             * Регистрация пользователя в системе
             * В случае успешной регистрации создается экземпля класса User,
             * в котором содержится информация о текущем пользователе
             */
            User.Singin(login, password);
            /* 
             * Доступ к единственному экземпляру 
             * с целлю получить имя текущего пользователя
             */
            Console.WriteLine("Welcome " + User.Instance.Login + "!");
        }
    }
}
