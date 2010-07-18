using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace mp3Collader.Instance
{
    public interface IDataProvider<TResultTable> where TResultTable : new()
    {
        IEnumerable<TResultTable> GetDataFromStoredProcedureAccessor(Database database);
        IEnumerable<TResultTable> GetDataFromSqlQueryStringAccessor(Database database);

        string StoredProcedureName
        {
            get;
            set;
        }

        string SqlQueryString
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
        private object[] dbParameterValues;

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

        public IEnumerable<TResultTable> GetDataFromStoredProcedureAccessor(Database database)
        {
            IParameterMapper paramMapper = new SimpleParameterMapper();
            IRowMapper<TResultTable> rowMapper = MapBuilder<TResultTable>.BuildAllProperties();

            DataAccessor<TResultTable> accessor =
                database.CreateSprocAccessor(storedProcedureName, paramMapper, rowMapper);

            // Execute the accessor to obtain the results
            return accessor.Execute(dbParameterValues);
        }

        public IEnumerable<TResultTable> GetDataFromSqlQueryStringAccessor(Database database)
        {
            IParameterMapper paramMapper = new SimpleParameterMapper();
            IRowMapper<TResultTable> rowMapper = MapBuilder<TResultTable>.BuildAllProperties();

            DataAccessor<TResultTable> accessor =
                database.CreateSqlStringAccessor(sqlQueryString, paramMapper, rowMapper);

            // Execute the accessor to obtain the results
            return accessor.Execute();
        }


    }

    public class DataProviderWithASynchronouseAccessor<ResultTable> where ResultTable : new()
    {  // database properties mapping and synchron Accessor execution
        public string StoredProcedureName;
        public object[] dbParameterValues;

        public List<ResultTable> Result;

        public void RunAsync(Database database)
        {
            try
            {
                // Create the accessor. This example uses the simplest overload.
                //var accessor = database.CreateSprocAccessor(storedProcedureName, mapper);

                IParameterMapper paramMapper = new SimpleParameterMapper();
                IRowMapper<ResultTable> rowMapper = MapBuilder<ResultTable>.BuildAllProperties();

                DataAccessor<ResultTable> accessor =
                    database.CreateSprocAccessor(StoredProcedureName, paramMapper, rowMapper);

                // Execute the accessor asynchronously, passing in the callback handler, 
                // the existing accessor as the AsyncState, and the parameter values.
                IAsyncResult async = accessor.BeginExecute(MyEndExecuteCallback, accessor, dbParameterValues);
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
                DataAccessor<ResultTable> accessor = async.AsyncState as DataAccessor<ResultTable>;
                Result = accessor.EndExecute(async).ToList();
            }
            catch
            {
                // handle any execution completion errors here
            }
        }


    }


}
