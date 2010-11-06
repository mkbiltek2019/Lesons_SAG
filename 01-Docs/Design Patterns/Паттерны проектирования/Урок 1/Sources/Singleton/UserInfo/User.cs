using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserInfo
{
    public class User
    {

        public string Login { get; set; }
        protected string Password { get; set; }

        /*
         * Защищенный конструктор, запрещающий создание экземпляра класса с внешнего кода
         */
        protected User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        // Единственный экземпляр класса
        private static User instance = null;
        // Свойство для внешнеого доступа к единственному экземпляру
        public static User Instance
        {
            get
            {
                return instance;
            }
        }

        // Свойство, показывающие, есль ли в системе зарегистрированный пользователь
        public static bool IsAuthenficated
        {
            get
            {
                return instance != null;
            }
        }

        // Регистрация (аутентификация) пользователя
        public static void Singin(string login, string password)
        {
            Singout();
            // Проверка коректности логина и пароля
            instance = new User(login, password);
        }

        // Выход пользователя из системы
        public static void Singout()
        {
            instance = null;
        }

    }
}