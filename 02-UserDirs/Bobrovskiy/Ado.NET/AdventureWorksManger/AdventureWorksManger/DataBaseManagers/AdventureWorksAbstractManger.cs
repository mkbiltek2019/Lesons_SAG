using System;
using System.Data;
using AdventureWorksManger.AdventureWorksLTDataSetTableAdapters;

namespace AdventureWorksManger
{
    public class AdventureWorksAbstractManger//:IDisposable 
    {
        protected string TableName
        {
            get;
            set;
        }

        protected AdventureWorksAbstractManger()
        {
        }

        protected AdventureWorksAbstractManger(string tableName)
        {
            TableName = tableName;
        }
        
        public DataTable ExtractDataColumnCollection(object dataSource)
        {
            DataTable resultDataTable = null;

            using (DataTable dataTable = ((DataSet)dataSource).Tables[TableName])
            {
                resultDataTable = dataTable.Clone();
            }

            return resultDataTable;
        }
    
    }

}
