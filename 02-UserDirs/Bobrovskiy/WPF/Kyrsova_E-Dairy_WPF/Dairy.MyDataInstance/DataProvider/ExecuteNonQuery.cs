using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Instance
{
    public class ExecuteStoredProcWithParam
    {
        #region Fields

        private DbCommand dbCommand = null;
        private Database database = null;
        private string storedProcedureName = string.Empty;

        #endregion

        #region Properties

        public Database DatabaseInstance
        {
            get
            {
                return database;
            }
            set
            {
                database = value;
            }
        }

        public string StoredProcedureName
        {
            get
            {
                return storedProcedureName;
            }
            set
            {
                storedProcedureName = value;
                InitCommand();
            }
        }

        #endregion

        private void InitCommand()
        {
            dbCommand = database.GetStoredProcCommand(storedProcedureName);
        }

        public void AddInParameter(object value, string parameterName)
        {
            database.AddParameter(dbCommand, parameterName,
                 DbType.DateTime, ParameterDirection.Input,
                 null, DataRowVersion.Default, value);
        }

        public void AddOutParameter(string parameterName)
        {
            database.AddParameter(dbCommand, parameterName, DbType.Int32,
               ParameterDirection.ReturnValue, null,
               DataRowVersion.Default, null);
        }

        public int ExecuteSpGetResultValue(string returnParameterName)
        {
            ExecuteSp();
            return Convert.ToInt32(database.GetParameterValue(dbCommand, returnParameterName));
        }

        public void ExecuteSp()
        {
            database.ExecuteNonQuery(dbCommand);
        }
    }
}
