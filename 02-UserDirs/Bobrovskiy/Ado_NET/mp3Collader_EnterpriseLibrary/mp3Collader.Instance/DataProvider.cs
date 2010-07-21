using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace mp3Collader.Instance
{
    public interface IDataProvider<TResultTable> where TResultTable : new()
    {
        IEnumerable<TResultTable> GetDataFromStoredProcedureAccessor(Database database, object[] param, IRowMapper<TResultTable> mapper);
        
        string StoredProcedureName
        {
            get;
            set;
        }
       
        object[] DbParameterValues
        {
            get;
            set;
        }
    }

    public class DataProviderWithSynchronouseAccessor<TResultTable> : IDataProvider<TResultTable> where TResultTable : new()
    {  // database properties mapping and synchron Accessor execution
        private string sqlQueryString = string.Empty;
        private string storedProcedureName = string.Empty;
        private object[] dbParameterValues = null;
      
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

        public string SqlQueryString
        {
            get
            {
                return sqlQueryString;
            }
            set
            {
                sqlQueryString = value;
            }
        }

        public object[] DbParameterValues
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

        public IEnumerable<TResultTable> GetDataFromStoredProcedureAccessor(Database database, object[] param, IRowMapper<TResultTable> mapper)
        {
            IParameterMapper paramMapper = new SimpleParameterMapper();
         
            DataAccessor<TResultTable> accessor =
                database.CreateSprocAccessor(storedProcedureName, paramMapper, mapper);
           
            return accessor.Execute(param);
        } 

    }

    public class DataProviderWithASynchronouseAccessor<TResultTable> where TResultTable : new()
    {  // database properties mapping and synchron Accessor execution
        public string StoredProcedureName;
        public object[] dbParameterValues;

        public List<TResultTable> result;

        public List<TResultTable> Result
        {
            get
            {
                if (executionState)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        private bool executionState = false;

        public void RunAsync(Database database, object[] param, IRowMapper<TResultTable> rowMapper)
        {
            try
            {
               IParameterMapper paramMapper = new SimpleParameterMapper();
             
                DataAccessor<TResultTable> accessor =
                    database.CreateSprocAccessor(StoredProcedureName, paramMapper, rowMapper);

                // Execute the accessor asynchronously, passing in the callback handler, 
                // the existing accessor as the AsyncState, and the parameter values.
                IAsyncResult async = accessor.BeginExecute(MyEndExecuteCallback, accessor, param);
            }
            catch
            {
                // handle any execution initiation errors here
            }
        }

        // callback handler that executes when call completes
        public void MyEndExecuteCallback(IAsyncResult async)
        {
            try
            {
                // obtain the results from the accessor
                DataAccessor<TResultTable> accessor = async.AsyncState as DataAccessor<TResultTable>;
                result = accessor.EndExecute(async).ToList();
                executionState = true;
            }
            catch
            {
                // handle any execution completion errors here
            }
        }
    }


}
