using System.Collections.Generic;
using System.Linq;
using Model;
using Instance.DataProvider;
using My = Dairy.MyDataInstance.DataProvider.Resources;

namespace Dairy.MyDataInstance.DataProvider
{
    public interface IDataOperator
    {
        List<DairyListItem> Select();
        void Insert();
        void Update();
        void Delete();
    }

    public class TableAssemblyWorker : IDataOperator
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

    }
}
