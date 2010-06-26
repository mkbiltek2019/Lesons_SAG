using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace UsersDictionary.DataAccess
{
    public class DBConnectionFactory
    {
        public static SqlConnection GetConnection()
        { 
            string connectionString = ConfigurationManager.ConnectionStrings["UsersDB"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }
}
