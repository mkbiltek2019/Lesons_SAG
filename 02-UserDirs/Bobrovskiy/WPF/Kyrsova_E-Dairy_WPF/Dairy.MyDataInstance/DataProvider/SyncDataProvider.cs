using System.Collections.Generic;
using Instance.DataProvider;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Dairy.DataAccess.DataProvider;

namespace Dairy.MyDataInstance.DataProvider
{
    public class DataProviderWithSynchronouseAccessor<TResultTable> :
                                        IDataProvider<TResultTable> where TResultTable : new()
    {            
        private Database currentDatabaseInstance=null;
        private IRowMapper<TResultTable> resultTableMapper;

        public Database CurrentDatabaseInstance
        {           
            set
            {
                currentDatabaseInstance = value;
            }
        }        

        public DataProviderWithSynchronouseAccessor()
        {
           resultTableMapper = MapBuilder<TResultTable>.MapAllProperties().Build();
        }
        
        public IEnumerable<TResultTable> Run(StoredProcedure storedProcedure)
        {  
            //An output mapper takes the result set returned from a database 
            DataAccessor<TResultTable> resultTableAccessor = currentDatabaseInstance.CreateSprocAccessor(
                                                                            storedProcedure.Name, 
							                                                storedProcedure.ParameterMapper,
							                                                resultTableMapper);

            return resultTableAccessor.Execute(storedProcedure.ParameterValues);
        }

    }   //class

}//namespace
