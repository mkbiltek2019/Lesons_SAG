using System;
using Helpers.Console;
using System.Collections;

using Helpers.DataBaseManagement;
/*
 Використовуючи АДО .НЕТ
 * підєднатись до бази AdventureWorks
 * Розробити меню з 4-пунктів (запити до таблиці Customer):
 * 1) вибірка даних з Бази (перегляд даних)
 * 2) видалення даних про користувача за номером
 * 3) вставка даних в таблицю Customer
 * 4) вивід даних з таблиці  Customer з пейджингом
 */
namespace ConsoleMenuSample
{
    class Program
    {
        //database AdventureWorks

        static void Main(string[] args)
        {
            ArrayList myList = new ArrayList();
            ConsoleDataBaseManager manager = null;
            using (manager = new ConsoleDataBaseManager())
            {
                myList.Add(new ConsoleMenuItem() { Action = manager.ShowCustomerData, Key = "1", Description = "View dataBase data", Visible = true });
                myList.Add(new ConsoleMenuItem() { Action = manager.DeleteDataById, Key = "2", Description = "Delete Data By ID", Visible = true });
                myList.Add(new ConsoleMenuItem() { Action = manager.InsertData, Key = "3", Description = "Insert some data", Visible = true });
                myList.Add(new ConsoleMenuItem() { Action = manager.ShowDataByPageNumber, Key = "4", Description = "Watch Customer data with paging", Visible = true });

                myList.Add(new ConsoleMenuItem() { Action = delegate() { return 0; }, Key = "5", Description = "Exit from menu", Visible = true });

                ConsoleMenu mainMenu = new ConsoleMenu(myList);

                mainMenu.NextMenuItemKey = ConsoleKey.DownArrow;
                mainMenu.PreviousMenuItemKey = ConsoleKey.UpArrow;
                mainMenu.SelectMenuItemKey = ConsoleKey.Enter;

                mainMenu.Display();

            }
        }
    }

}
