using System;
using System.Data;

namespace AdventureWorksManger
{
    public delegate int UpdateHandler(AdventureWorksLTDataSet dataSet);

    public interface IUpdateable
    {
        void Update(UpdateHandler handler, AdventureWorksLTDataSet dataTable);    
    }

    //-- AdventureWorksTableManager class use automaticaly
    //-- generated class AdventureWorksLTDataSet by Wizard !!!!

    public class AdventureWorksTableManager : AdventureWorksAbstractManger, IUpdateable
    {
        public AdventureWorksTableManager(string tableName)
            : base(tableName)
        {
        }

        public void Update(UpdateHandler handler, AdventureWorksLTDataSet dataTable)
        {
            try
            {
                handler.Invoke(dataTable);
            }
            catch (Exception ex)
            {
            }
        }
    }

}
