using System.Configuration;
using System.Data.SqlClient;

namespace mp3Collader.DataAccess
{
    public class DBConnectionFactory
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = 
                ConfigurationManager.ConnectionStrings["MediaLibrary"].ConnectionString;

            return new SqlConnection(connectionString);
        }
    }
}
