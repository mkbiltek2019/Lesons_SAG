using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace mp3Collader.DataAccess
{
    public class DbFactory
    {
        public Database CreateDatabase()
        {
          return  new SqlDatabase(DBConnectionFactory.GetConnection().ConnectionString);
        }
       
    }
}
