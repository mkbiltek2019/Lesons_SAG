using System.Collections.Generic;
using System.Linq;
using Dairy.DataAccess;
using Dairy.MyDataInstance.DataProvider;
using Dairy.MyDataInstance.DataProvider.Resources;
using Instance;
using Instance.DataProvider;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Model;

namespace Dairy.MyDataInstance
{
    public class TableController<TableModel> where TableModel : new()
    {
        #region  Fields

        private Database currentDatabase = null;
        private IDataProvider<TableModel> asyncDataProvider = null;

        private IDataProvider<TableModel> syncDataProvider = null;
        private ExecuteStoredProcWithParam dataProvider = null;

        private IList<TableModel> result;

        #endregion

        #region  Properties

        public IList<TableModel> Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

        #endregion

        public TableController()
        {
            currentDatabase = (new DbFactory()).CreateDatabase();
        }

        #region private  methods

        private void InitSimple(string spName)
        {
            dataProvider = new ExecuteStoredProcWithParam
                               {
                                   DatabaseInstance = currentDatabase,
                                   StoredProcedureName = spName
                               };
           
        }

        private void InitAsync()
        {
            asyncDataProvider = new DataProviderWithASynchronouseAccessor<TableModel>();
            asyncDataProvider.CurrentDatabaseInstance = currentDatabase;
        }

        private void InitSync()
        {
            syncDataProvider = new DataProviderWithSynchronouseAccessor<TableModel>();
            syncDataProvider.CurrentDatabaseInstance = currentDatabase;
        }
        
        #endregion

        public List<TableModel> ExecuteAsync(object[] storedProcedureParam, string storedProcedureName)
        {
            InitAsync();

            asyncDataProvider.StoredProcedureName = storedProcedureName;
            asyncDataProvider.DatabaseParameterValue = storedProcedureParam;

            return asyncDataProvider.Run() as List<TableModel>;
        }

        public List<TableModel> ExecuteSync(object[] storedProcedureParam, string storedProcedureName)
        {
            InitSync(); 

            syncDataProvider.StoredProcedureName = storedProcedureName;
            syncDataProvider.DatabaseParameterValue = storedProcedureParam;

            return syncDataProvider.Run().ToList();
        }

        public int Execute(object[] storedProcedureParam, string storedProcedureName)
        {
            const string outParameterName = "result";

            InitSimple(storedProcedureName);
           
            foreach (ParameterItem parameterItem in storedProcedureParam)
            {
               dataProvider.AddInParameter(
                   parameterItem.ParameterValue,
                   parameterItem.ParameterName
                   ); 
            }

            dataProvider.AddOutParameter(outParameterName);

            try
            {
                return dataProvider.ExecuteSpGetResultValue(outParameterName);
            }catch
            { 
            }

            return 0;
        }

    }//class 

}//namespace
