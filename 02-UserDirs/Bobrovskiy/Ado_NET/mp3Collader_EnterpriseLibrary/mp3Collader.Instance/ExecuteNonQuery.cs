using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace mp3Collader.Instance
{
    public class ExecuteStoredProcWithParam
    {
        private DbCommand dbCommand;
       
        public ExecuteStoredProcWithParam(Database dataBase, string storedProcedureName)
        {
            dbCommand = dataBase.GetStoredProcCommand(storedProcedureName);
        }

        public void AddInParameter(Database database, object value, string parameterName)
        {
            database.AddParameter(dbCommand, parameterName,
                 DbType.String, ParameterDirection.Input,
                 null, DataRowVersion.Default, value);
        }

        public void AddOutParameter(Database database, string parameterName)
        {
            database.AddParameter(dbCommand, parameterName, DbType.Int32,
               ParameterDirection.ReturnValue, null,
               DataRowVersion.Default, null);
        }

        public int ExecuteSpSetResultValue(Database database, string returnParameterName)
        {
            database.ExecuteNonQuery(dbCommand);
            return Convert.ToInt32(database.GetParameterValue(dbCommand, returnParameterName));
        }

        public void ExecuteSp(Database database)
        {
            database.ExecuteNonQuery(dbCommand);
        }
    }
}
