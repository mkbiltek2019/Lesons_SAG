using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Helpers.DataBasePrinter
{
    public class DataPrinter
    {
        private void PrintTableHeaderForCustomerData()
        {
            //---------------------------------------12-----------------------------------------------------14----------
            System.Console.WriteLine(@"┌──────────┬────────────┬────────────┬────────────┬───────────────────────────┐");
            System.Console.WriteLine(@"│CustomerID│FirstName   │LastName    │Phone       │CompanyName                │");
            System.Console.WriteLine(@"├──────────┼────────────┼────────────┼────────────┼───────────────────────────┤");
        }

        private void PrintTableBottomForCustomerData()
        {
            //-------------------------------12---------------------------------------------------------------14--------
            System.Console.WriteLine(@"└──────────┴────────────┴────────────┴────────────┴───────────────────────────┘");
        }

        public void ShowCustomerData(SqlDataReader reader)
        {
            System.Console.Clear();

            PrintTableHeaderForCustomerData();
            string  format = "│{0,-10:G}│{1,-12:G}│{2,-12:G}│{3,-12:G}│{4,-27:G}│";

            while (reader.Read())
            {
                System.Console.WriteLine(format,
                                reader["CustomerID"],
                                reader["FirstName"],
                                reader["LastName"],
                                reader["Phone"],
                                reader["CompanyName"]
                                );
            }
            PrintTableBottomForCustomerData();

            System.Console.ReadKey();
        }

    }
}
