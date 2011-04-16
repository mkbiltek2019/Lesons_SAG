using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace SMODemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerConnection serverConnection = new ServerConnection("localhost", "sa", "123456");
            Server server = new Server(serverConnection);
            var clientRegistry = server.Databases
                .Cast<Database>()
                .Single(db => db.Name == "ClientRegistry");

            //foreach (Database db in server.Databases)
            //{
            //    Console.WriteLine("[DATABASE] {0}:", db.Name);
            //    foreach (Table item in db.Tables)
            //    {
            //        Console.WriteLine("\t[TABLE] {0}:", item.Name);
            //        foreach (Column column in item.Columns)
            //        {
            //            Console.WriteLine("\t\t{0}:{1}", column.Name, column.DataType);
            //        }
            //    }
            //}

            Console.WriteLine("[DATABASE] {0}:", clientRegistry.Name);
            foreach (Table item in clientRegistry.Tables)
            {
                Console.WriteLine("\t[TABLE] {0}:", item.Name);
                foreach (Column column in item.Columns)
                {
                    Console.WriteLine("\t\t{0}:{1}", column.Name, column.DataType);
                }
            }
        }
    }
}
