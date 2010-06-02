using System.Data;

namespace AdventureWorksManger
{
    public abstract class AdventureWorksAbstractManger 
    {
        public string TableName
        {
            get;
            set;
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
