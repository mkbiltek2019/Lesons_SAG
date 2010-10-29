using System.Collections.Generic;
using System.Linq;
using Dairy.DataAccess;
using Dairy.MyDataInstance.DataProvider;
using Instance;
using Instance.DataProvider;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Dairy.DataAccess.DataProvider;
using System;

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

    public class TableController<TResultTable> where TResultTable : new()
    {
        #region  Fields

        private Database currentDatabase = null;
        private IDataProvider<TResultTable> asyncDataProvider = null;

        private IDataProvider<TResultTable> syncDataProvider = null;
        private ExecuteStoredProcWithParam dataProvider = null;

        private IList<TResultTable> result;

        #endregion

        #region  Properties

        public IList<TResultTable> Result
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
            InitAsync();
            InitSync(); 
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
            asyncDataProvider = new DataProviderWithASynchronouseAccessor<TResultTable>();
            asyncDataProvider.CurrentDatabaseInstance = currentDatabase;
        }

        private void InitSync()
        {
            syncDataProvider = new DataProviderWithSynchronouseAccessor<TResultTable>();
            syncDataProvider.CurrentDatabaseInstance = currentDatabase;
        }
        
        #endregion

        public List<TResultTable> ExecuteAsync(StoredProcedure storedProcedure)
        {
            return syncDataProvider.Run(storedProcedure) as List<TResultTable>;
        }

        public List<TResultTable> ExecuteSync(StoredProcedure storedProcedure)
        {
            return syncDataProvider.Run(storedProcedure).ToList();
        }

        public int Execute(StoredProcedure storedProcedure)
        {
            /// The result value must have some name
            const string outParameterName = "result";
            int result = 0;

            InitSimple(storedProcedure.Name);

            foreach (ParameterItem parameterItem in storedProcedure.ParameterValueCollection)
            {
               dataProvider.AddInParameter(
                   parameterItem.ParameterValue,
                   parameterItem.ParameterName); 
            }

            dataProvider.AddOutParameter(outParameterName);

            try
            {
                result = dataProvider.ExecuteSpGetResultValue(outParameterName);
            }
            catch
            {
                throw new Exception("Execute(StoredProcedure storedProcedure) has failed to execute");
                result = 0;
            }

            return result;
        }

    }//class 

}//namespace
