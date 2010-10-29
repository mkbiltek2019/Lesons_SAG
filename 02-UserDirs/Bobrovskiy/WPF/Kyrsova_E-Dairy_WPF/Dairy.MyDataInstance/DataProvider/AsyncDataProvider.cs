using System;
using System.Collections.Generic;
using System.Linq;
using Instance.DataProvider;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Dairy.DataAccess.DataProvider;

namespace Dairy.MyDataInstance.DataProvider
{
    /// <summary>
    /// // database properties mapping and synchron Accessor execution
    /// </summary>

    //TODO: check this not work properly

    public class DataProviderWithASynchronouseAccessor<TResultTable> :
                        IDataProvider<TResultTable> where TResultTable : new()
    {
        private Database database = null;
        public List<TResultTable> result = null;
        public IAsyncResult asyncResult = null;

        public Database CurrentDatabaseInstance
        {
            set
            {
                database = value;
            }
        }

        public List<TResultTable> Result
        {
            get;
            set;
        }

        public IEnumerable<TResultTable> Run(StoredProcedure storedProcedure)
        {
            try
            {
                IRowMapper<TResultTable> resultTableMapper = MapBuilder<TResultTable>.MapAllProperties().Build();

                DataAccessor<TResultTable> accessor = database.CreateSprocAccessor(
                            storedProcedure.Name,
                            storedProcedure.ParameterMapper,
                            resultTableMapper);

                // Execute the accessor asynchronously, passing in the callback handler, 
                // the existing accessor as the AsyncState, and the parameter values.

                asyncResult = accessor.BeginExecute(MyEndExecuteCallback,
                            accessor,
                            storedProcedure.ParameterValues);

            }
            catch
            {
                // handle any execution initiation errors here
                throw new Exception("Asyn operation has failed in method  public IEnumerable<TResultTable> Run(StoredProcedure storedProcedure) ");
            }

            return result;
        }

        // callback handler that executes when call completes
        public void MyEndExecuteCallback(IAsyncResult async)
        {
            try
            {
                // obtain the results from the accessor
                DataAccessor<TResultTable> accessor =
                            async.AsyncState as DataAccessor<TResultTable>;

                if (accessor != null)
                {
                    result = accessor.EndExecute(async).ToList();
                }
            }
            catch
            {
                throw new Exception("Asyn operation has failed in method  MyEndExecuteCallback(IAsyncResult async)");
            }
        }


    }//class

}//namespace
