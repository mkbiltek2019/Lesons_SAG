using System;
using System.Collections.Generic;
using System.Linq;
using Instance.DataProvider;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Dairy.MyDataInstance.DataProvider
{
    /// <summary>
    /// // database properties mapping and synchron Accessor execution
    /// </summary>
    
    public class DataProviderWithASynchronouseAccessor<TResultTable>:
                        IDataProvider<TResultTable> where TResultTable : new()
    {
        #region fields
      
        private string storedProcedureName=string.Empty;
        private Database database = null;
        public List<TResultTable> result=null;
        public IAsyncResult asyncResult = null; 

        private object[] dbParameterValues= new object[0];

        #endregion

        #region properties

        public string StoredProcedureName
        {
            get
            {
                return storedProcedureName;
            }
            set
            {
                storedProcedureName = value;
            }
        }

        public Database CurrentDatabaseInstance
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

        public object[] DatabaseParameterValue
        {
            get
            {
                return dbParameterValues;
            }
            set
            {
                dbParameterValues = value; 
            }
        }

        public List<TResultTable> Result
        { 
           get;
           set;
        }

        #endregion

        public IEnumerable<TResultTable> Run()     
        {
            try
            {
                IParameterMapper paramMapper = new SimpleParameterMapper();
                IRowMapper<TResultTable> mapper = MapBuilder<TResultTable>.MapAllProperties().Build();

                DataAccessor<TResultTable> accessor =
                    database.CreateSprocAccessor(storedProcedureName, paramMapper, mapper);
                  
                // Execute the accessor asynchronously, passing in the callback handler, 
                // the existing accessor as the AsyncState, and the parameter values.
                asyncResult = accessor.BeginExecute(MyEndExecuteCallback, accessor, dbParameterValues);
               
            }
            catch
            {
                // handle any execution initiation errors here
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
                if (accessor!=null)
                {
                   result = accessor.EndExecute(async).ToList();
                }   
            }
            catch
            {
                // handle any execution completion errors here
            }
        }

      
    }//class

}//namespace
