using System.Collections.Generic;
using System.Linq;
using Dairy.DataAccess;
using Dairy.MyDataInstance.DataProvider;
using Instance;
using Instance.DataProvider;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Dairy.MyDataInstance
{
    /// <summary>
    /// This generic class
    /// used to bind parameter to data providers
    /// instantiate Database class
    /// and run one of provider under execution
    /// SyncDataProvider and  ASyncDataProvider
    /// can't return as result one value
    /// They returns IEnumerable collection
    /// </summary>
    /// <typeparam name="TableModel"></typeparam>
    /// TableModel it used for Async and Sync Dataprovider generics
    /// they have one method Run that return IEnumerable collection as result
    /// Output result column names
    /// that returned Run method the same like stored procedure result fields
    /// and must be the same like
    /// TableModel colunm name other wise you don't get any result
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
            /// The result value must have some name
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
                return 0;
            }

            return 0;
        }

    }//class 

}//namespace
