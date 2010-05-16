using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace IsCompletedExample
{
    class ADOAsyncDemo
    {
        [STAThread]
        static void Main()
        {
            string commandText =
              "UPDATE Production.Product SET ReorderPoint = " +
              "ReorderPoint + 1 " +
              "WHERE ReorderPoint Is Not Null;" +
              "WAITFOR DELAY '0:0:3';" +
              "UPDATE Production.Product SET ReorderPoint = " +
              "ReorderPoint - 1 " +
              "WHERE ReorderPoint Is Not Null";

            RunCommandAsynchronously(
                commandText, GetConnectionString());

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private static void RunCommandAsynchronously(
          string commandText, string connectionString)
        {
            using (SqlConnection connection =
              new SqlConnection(connectionString))
            {
                try
                {
                    int count = 0;
                    SqlCommand command = 
                        new SqlCommand(commandText, connection);
                    connection.Open();

                    IAsyncResult result = 
                        command.BeginExecuteNonQuery();
                    while (!result.IsCompleted)
                    {
                        Console.WriteLine(
                                        "Waiting ({0})", count++);
                        // Wait for 1/10 second, so the counter
                        // doesn't consume all available 
                        // resources on the main thread.
                        System.Threading.Thread.Sleep(100);
                    }
                    Console.WriteLine(
                        "Command complete. Affected {0} rows.",
                    command.EndExecuteNonQuery(result));
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error ({0}): {1}", 
                        ex.Number, ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        private static string GetConnectionString()
        {
            return "Data Source=(local);Integrated Security=SSPI;" +
            "Initial Catalog=Works; " +
            "Asynchronous Processing=true";
        }
    }
}
