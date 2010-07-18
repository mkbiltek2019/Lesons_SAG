using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace mp3Collader.DataAccess
{
    public class DbFactory
    {
        public SqlDatabase CreateDatabase()
        {
          return  new SqlDatabase(DBConnectionFactory.GetConnection().ConnectionString);
        }
       
    }
}
