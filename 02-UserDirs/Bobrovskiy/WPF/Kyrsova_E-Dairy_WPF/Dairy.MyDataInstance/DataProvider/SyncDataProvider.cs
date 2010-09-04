using System.Collections.Generic;
using Instance.DataProvider;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Dairy.MyDataInstance.DataProvider
{
    /// <summary>
    /// Generic class that with one
    /// method Run()  it use DataAccessor generic from
    /// entlib to get result from database
    /// as result of execution of stored procedure we get
    /// IEnumerable collection.
    /// <Restriction>
    /// Stored procedure result column names must be the same like
    /// TResultTable field names. It's important!!! 
    /// </Restriction>
    /// </summary>
    /// <typeparam name="TResultTable"></typeparam>
    public class DataProviderWithSynchronouseAccessor<TResultTable> :
                                        IDataProvider<TResultTable> where TResultTable : new()
    {
        #region Fields

        private string storedProcedureName = string.Empty;
        private Database currentDatabaseInstance=null;
        private object[] dbParameterValues = new object[0];

        #endregion

        #region Properties

        public Database CurrentDatabaseInstance
        {
            get
            {
                return currentDatabaseInstance;
            }
            set
            {
                currentDatabaseInstance = value;
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

        #endregion

        public IEnumerable<TResultTable> Run()
        {
            IParameterMapper paramMapper = new SimpleParameterMapper();
            IRowMapper<TResultTable> mapper = MapBuilder<TResultTable>.MapAllProperties().Build();

            DataAccessor<TResultTable> accessor =
                currentDatabaseInstance.CreateSprocAccessor(storedProcedureName, paramMapper, mapper);

            return accessor.Execute(dbParameterValues);
        }

    }   //class

}//namespace
