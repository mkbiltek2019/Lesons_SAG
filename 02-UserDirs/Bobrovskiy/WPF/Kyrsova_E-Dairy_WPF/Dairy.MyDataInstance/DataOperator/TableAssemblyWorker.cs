using System;
using System.Collections.Generic;
using System.Linq;
using Dairy.MyDataInstance.DataOperator;
using Model;
using Instance.DataProvider;
using My = Dairy.MyDataInstance.DataProvider.Resources;

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
            return (new TableController<DairyListItem>()).ExecuteSync(
               ParameterProvider.GetParameterListForInsertDairyDateItem(new DairyDateItem()
                                                                            {
                                                                                Date = DateTime.Now
                                                                            }),
               My.Resources.CreateSelectByNameSPList()[TableList.DiaryListItem].ToString()).ToList();
        }      

        public List<DairyListItem> Select()
        {
            return dairyItemController.ExecuteSync(
                ParameterProvider.GetParameterListForInsertDairyDateItem(DateItem),
                My.Resources.CreateSelectByNameSPList()[TableList.DiaryListItem].ToString()).ToList();
        }

        public void Insert()
        {
            ListItem.DateID = dairyController.Execute(
                ParameterProvider.GetParameterListForInsertDairyDateItem(DateItem),
                My.Resources.CreateInsertSPList()[TableList.DiaryDate].ToString());

            dairyItemController.ExecuteAsync(
                ParameterProvider.GetParameterListForInsertDairyListItem(ListItem),
                My.Resources.CreateInsertSPList()[TableList.DiaryListItem].ToString());

        }

        public void Update()
        {
            dairyItemController.ExecuteSync(
                ParameterProvider.GetParameterListForSelectDairyListItem(ListItem),
                My.Resources.CreateUpdateSPList()[TableList.DiaryListItem].ToString());
        }

        public void Delete()
        {
            dairyItemController.ExecuteSync(
                ParameterProvider.GetParameterListForDeleteDairyItem(ListItem.ItemID),
                My.Resources.CreateDeleteSPList()[TableList.DiaryListItem].ToString());
        } 

        public int ComputeStatistic()
        {
          return  dairyController.Execute(
                ParameterProvider.GetParameterListForInsertDairyDateItem(DateItem),
                My.Resources.CreateInsertSPList()[TableList.DiaryDate].ToString());
        }



    }  //class

}  //namespace
