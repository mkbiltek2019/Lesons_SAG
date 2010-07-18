using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace mp3Collader.Instance
{
    public class ExecuteStoredProcWithParam
    {
        private DbCommand dbCommand;
        public int resultValue = 0;

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

        public void ExecuteSpSetResultValue(Database database, string returnParameterName)
        {
            database.ExecuteNonQuery(dbCommand);
            resultValue = Convert.ToInt32(database.GetParameterValue(dbCommand, returnParameterName));
        }
    }
}
