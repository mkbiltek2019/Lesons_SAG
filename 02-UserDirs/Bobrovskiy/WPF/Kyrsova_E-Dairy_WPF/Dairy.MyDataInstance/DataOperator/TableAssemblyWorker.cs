using System;
using System.Collections.Generic;
using System.Linq;
using Dairy.MyDataInstance.DataOperator;
using Model;
using Instance.DataProvider;
using My = Dairy.MyDataInstance.DataProvider.Resources;
using Dairy.DataAccess.DataProvider;

namespace Dairy.MyDataInstance.DataProvider
{
    /// <summary>
    /// class TableAssemblyWorker
    /// It knows about stored procedures and it's parameters
    /// It instantiate table controler for some model
    /// It use table controller that manipulate data in database
    /// Insert, Select, Update, Delete
    /// 
    /// In our case we have two model
    /// Application model with InotifyPropertyChanger
    /// and database model
    /// becouse IU processing must be separated from database processing
    /// </summary>
    public class TableAssemblyWorker : IDataOperator, IStatisticProvider
    {
        #region Fields

        private TableController<DairyDateItem> dairyController;
        private TableController<DairyListItem> dairyItemController;

        #endregion

        #region Properties

        public DairyListItem ListItem
        {
            get;
            set;
        }

        public DairyDateItem DateItem
        {
            get;
            set;
        }

        #endregion

        public TableAssemblyWorker()
        {
            dairyController = new TableController<DairyDateItem>();
            dairyItemController = new TableController<DairyListItem>();
        }

        public List<DairyListItem> StartUpSelect()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.Name = My.Resources.CreateSelectByNameSPList()[TableList.DiaryListItem].ToString();
            storedProcedure.ParameterValueCollection =  ParameterProvider.GetParameterListForInsertDairyDateItem(new DairyDateItem()
                                                                            {
                                                                                Date = DateTime.Now
                                                                            });

            return (new TableController<DairyListItem>()).ExecuteSync(storedProcedure).ToList();
        }      

        public List<DairyListItem> Select()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.Name = My.Resources.CreateSelectByNameSPList()[TableList.DiaryListItem].ToString();
            storedProcedure.ParameterValueCollection =  ParameterProvider.GetParameterListForInsertDairyDateItem(DateItem);

            return dairyItemController.ExecuteSync(storedProcedure).ToList();
        }

        public void Insert()
        {
            StoredProcedure firstStoredProcedure = new StoredProcedure();
            firstStoredProcedure.Name = My.Resources.CreateInsertSPList()[TableList.DiaryDate].ToString();
            firstStoredProcedure.ParameterValueCollection = ParameterProvider.GetParameterListForInsertDairyDateItem(DateItem);

            ListItem.DateID = dairyController.Execute(firstStoredProcedure);

            StoredProcedure secondStoredProcedure = new StoredProcedure();
            secondStoredProcedure.Name = My.Resources.CreateInsertSPList()[TableList.DiaryListItem].ToString();
            secondStoredProcedure.ParameterValueCollection = ParameterProvider.GetParameterListForInsertDairyListItem(ListItem);

            dairyItemController.ExecuteAsync(secondStoredProcedure);
        }

        public void Update()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.Name = My.Resources.CreateUpdateSPList()[TableList.DiaryListItem].ToString();
            storedProcedure.ParameterValueCollection =   ParameterProvider.GetParameterListForSelectDairyListItem(ListItem);

            dairyItemController.ExecuteSync(storedProcedure);
        }

        public void Delete()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.Name = My.Resources.CreateDeleteSPList()[TableList.DiaryListItem].ToString();
            storedProcedure.ParameterValueCollection = ParameterProvider.GetParameterListForDeleteDairyItem(ListItem.ItemID);

            dairyItemController.ExecuteSync(storedProcedure);
        } 

        public int ComputeStatistic()
        {
            StoredProcedure storedProcedure = new StoredProcedure();
            storedProcedure.Name = My.Resources.CreateInsertSPList()[TableList.DiaryDate].ToString();
            storedProcedure.ParameterValueCollection = ParameterProvider.GetParameterListForInsertDairyDateItem(DateItem);

            return dairyController.Execute(storedProcedure);
        }


    }  //class

}  //namespace
