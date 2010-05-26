using System;
using System.Data.SqlClient;
using Helpers.Console;
using Helpers.DataBasePrinter;

namespace Helpers.DataBaseManagement
{
    static class Authentification
    {
        public static void ConsoleLoginAndPasswdInput(ref string curentLogin, ref string currentPasswd)
        {
            System.Console.Clear();
            System.Console.WriteLine("Please input authentification data.\n");
            System.Console.Write("Input Login: ");
            curentLogin = System.Console.ReadLine();
            System.Console.Write("Input passwd: ");
            currentPasswd = System.Console.ReadLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Push button.");
            System.Console.ReadKey();
            System.Console.Clear();
        }
    }

    public static class ConsoleDataReader
    {
        public static string ReadSomeValue(string message)
        {
            string result = string.Empty;
            System.Console.Clear();
            System.Console.Write(message);
            result = System.Console.ReadLine();
            System.Console.Clear();
            return result;
        }

    }

    public delegate void ActionHandler();
    public delegate void ActionWithParamHandler(SqlDataReader data);

    public class ConsoleDataBaseManager : IDisposable
    {
        private SqlConnection connection = null;

        string name = string.Empty;
        string pass = string.Empty;

        public ConsoleDataBaseManager()
        {
            Authentificate();
        }

        public void Dispose()
        {
            if ((connection != null) || (connection.State != System.Data.ConnectionState.Closed))
            {
                connection.Close();
            }
        }

        private void Authentificate()
        {
            Authentification.ConsoleLoginAndPasswdInput(ref name, ref pass);
        }

        public MenuResult ShowCustomerData()
        {
            using (connection = new SqlConnection())
            {
                SetConnectionStringAndOpenConnection();
                Action(new SqlCommand(@"
                        SELECT TOP 10
                           CustomerID,
                           FirstName,                           
                           LastName,                           
                           Phone,                           
                           CompanyName
                        FROM [AdventureWorksLT2008].[SalesLT].[Customer]", connection),
                                                                         (new DataPrinter()).ShowCustomerData);
            }

            System.Console.ReadKey();
            return MenuResult.Proceed;
        }

        private void Action(SqlCommand selectCommand, ActionWithParamHandler handler)
        {
            SqlCommand command = null;
            using (command = selectCommand)
            {
                SqlDataReader data = null;
                using (data = command.ExecuteReader())
                {
                    handler.Invoke(data);
                }
            }
        }

        private void Action(SqlCommand selectCommand)
        {
            SqlCommand command = null;
            using (command = selectCommand)
            {
                SqlDataReader data = null;
                using (data = command.ExecuteReader())
                {
                }
            }
        }

        private void SetConnectionStringAndOpenConnection()
        {
            connection.ConnectionString = string.Format(
                "Server=WINDA1;Database=AdventureWorksLT2008;User ID={0};Password={1}; Trusted_Connection=true;",
                name.Trim(new char[] { ':', ',', '\'', '/', '\\', ' ', '-' }),
                pass.Trim(new char[] { ':', ',', '\'', '/', '\\', ' ', '-' }));

            //"Server=WINDA1;Database=AdventureWorksLT2008;User ID=user;Password=1; Trusted_Connection=true;";

            connection.Open();
        }

        public MenuResult DeleteDataById()
        {
            using (connection = new SqlConnection())
            {
                SetConnectionStringAndOpenConnection();

                string result = ConsoleDataReader.ReadSomeValue("Input Customer ID for delete: ");

                int value = 0;
                if (int.TryParse(result, out value))
                {
                    Action(new SqlCommand(string.Format(@"
                        DELETE FROM 
	                         [AdventureWorksLT2008].[SalesLT].[Customer]
	                    WHERE 
	                         [AdventureWorksLT2008].[SalesLT].[Customer].[CustomerID] = {0}", result),
                                          connection));
                }
            }

            System.Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult InsertData()
        {
            using (connection = new SqlConnection())
            {
                SetConnectionStringAndOpenConnection();
                Action(new SqlCommand(string.Format(@"
                             INSERT INTO [AdventureWorksLT2008].[SalesLT].[Customer](
                                   [Title],[FirstName],[MiddleName],[LastName]
                                   ,[Suffix],[CompanyName] ,[SalesPerson] ,[EmailAddress]
                                   ,[Phone]  ,[PasswordHash] ,[PasswordSalt] ,[rowguid]
                                   ,[ModifiedDate])
                             VALUES(                                   
                                   {0},{1},{2},{3}
                                   ,{4},{5},{6},{7}
                                   ,{8}
                                   ,'000000','000000'
                                   ,NEWID(),GETDATE())"
                           , @"'Mr.'"
                           ,@"'Kola'"
                           ,@"'Peta'"
                           ,@"'Vasiya'"
                           ,@"null"
                           ,@"'A Bike Store'"
                           ,@"'adventure-works\pamela0'"
                           , @"'valnet13@gmail.com'"
                           ,@"'245-555-0173'"
                        ), connection));
            }

            System.Console.ReadKey();
            return MenuResult.Proceed;
        }

        public MenuResult ShowDataByPageNumber()
        {
            const int pageSize = 20;
            int pageNumber = 3;

            using (connection = new SqlConnection())
            {
                SetConnectionStringAndOpenConnection();
                Action(new SqlCommand(string.Format(@"                        
                        EXEC [dbo].[SalesLT.Customer.GetAllWithPaging]
	                    {0},
	                    {1}", pageSize, pageNumber), connection),
                        (new DataPrinter()).ShowCustomerData);
            }

            System.Console.ReadKey();
            return MenuResult.Proceed;
        }
    }
}
