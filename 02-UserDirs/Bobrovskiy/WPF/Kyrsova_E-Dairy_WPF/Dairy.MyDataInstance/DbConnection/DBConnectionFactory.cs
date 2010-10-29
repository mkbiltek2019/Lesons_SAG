using System.Configuration;

namespace Dairy.MyDataAccesse
{
    public class DBConnectionFactory
    {
        public static System.Data.SqlClient.SqlConnection GetConnection()
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["ElectronicDairy"].ConnectionString;

            return new System.Data.SqlClient.SqlConnection(connectionString);
        }
    }
}
