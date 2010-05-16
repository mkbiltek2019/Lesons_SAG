using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace GetProviderFactoryClassesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable t = GetProviderFactoryClasses();

            Console.ReadKey(true);
        }

        static DataTable GetProviderFactoryClasses()
        {
            DataTable table = DbProviderFactories.GetFactoryClasses();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine(row[column]);
                }
            }
            return table;
        }
    }
}
