using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CreateDbConnectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DbConnection connection =
                CreateDbConnection("System.Data.SqlClient",
                                   "Data Source=(local);" +
                                   "Integrated Security=SSPI;" +
                                   "Initial Catalog=AdventureWorks;"
                                   );

            ExecuteDbCommand(connection);

            Console.ReadKey(true);
        }

        static void ExecuteDbCommand(DbConnection connection)
        {
            if (connection != null)
            {
                using (connection)
                {
                    try
                    {
                        connection.Open();

                        DbCommand command = connection.CreateCommand();
                        command.CommandText =
                            "UPDATE Production.Product " +
                            "SET ReorderPoint = ReorderPoint + 1 " +
                            "WHERE ReorderPoint Is Not Null;" +
                            "UPDATE Production.Product " +
                            "SET ReorderPoint = ReorderPoint - 1 " +
                            "WHERE ReorderPoint Is Not Null";

                        int rows = command.ExecuteNonQuery();

                        Console.WriteLine("Updated {0} rows.", rows);
                    }

                    catch (DbException exDb)
                    {
                        Console.WriteLine("DbException.GetType: {0}", exDb.GetType());
                        Console.WriteLine("DbException.Source: {0}", exDb.Source);
                        Console.WriteLine("DbException.ErrorCode: {0}", exDb.ErrorCode);
                        Console.WriteLine("DbException.Message: {0}", exDb.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception.Message: {0}", ex.Message);
                    }
                }
            }
            else
            {
                Console.WriteLine("Failed: DbConnection is null.");
            }
        }

        static DbConnection CreateDbConnection(
            string providerName, string connectionString)
        {
            DbConnection connection = null;

            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory =
                        DbProviderFactories.GetFactory(providerName);

                    connection = factory.CreateConnection();
                    connection.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    if (connection != null)
                    {
                        connection = null;
                    }
                    Console.WriteLine(ex.Message);
                }
            }

            return connection;
        }
    }
}
