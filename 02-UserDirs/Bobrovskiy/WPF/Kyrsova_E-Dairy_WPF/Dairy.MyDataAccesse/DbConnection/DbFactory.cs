using Dairy.MyDataAccesse;

namespace Dairy.DataAccess
{
    public class DbFactory
    {
        public Microsoft.Practices.EnterpriseLibrary.Data.Database CreateDatabase()
        {
            return new Microsoft.Practices.EnterpriseLibrary.
                        Data.Sql.SqlDatabase(DBConnectionFactory.
                                             GetConnection().ConnectionString);
        }   
    }
}
