using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;

namespace Mvvm.Model
{
    /// <summary>
    /// Represents collection of persons
    /// </summary>
    public class DairyItemCollection : ObservableCollection<DairyItem>
    {
        /// <summary>
        /// Generates sample persons
        /// </summary>
        /// <returns></returns>
        //public static DairyItemCollection Generate()
        //{
        //    DairyItemCollection dairyItemCollection = new DairyItemCollection();
        //    //dairyItemCollection.Add(DairyItem.Create(1, 1, 1, 1, "Main bussiness", "Somework to do today"));
        //    //dairyItemCollection.Add(DairyItem.Create(2, 1, 2, 1, "Main some little bussiness", "Somework to do today"));
        //    //dairyItemCollection.Add(DairyItem.Create(3, 2, 1, 1, "Go to dinner", "Somework to do today just eat"));
        //    //dairyItemCollection.Add(DairyItem.Create(4, 2, 2, 1, "Important breakfast", "Somework to do today"));
        //    //dairyItemCollection.Add(DairyItem.Create(5, 3, 1, 1, "Some bussiness events", "Somework to do today"));
        //    //dairyItemCollection.Add(DairyItem.Create(6, 2, 1, 1, "Need to buy", "Somework to do today"));
        //    //dairyItemCollection.Add(DairyItem.Create(7, 2, 1, 1, "Go to that", "Somework to do today"));
        //    //dairyItemCollection.Add(DairyItem.Create(8, 2, 1, 1, "Incompleted job", "Somework to do today"));
        //    //dairyItemCollection.Add(DairyItem.Create(9, 3, 1, 1, "Go home and rest", "Somework to do today"));

        //    return dairyItemCollection;
        //}

        public static DairyItemCollection Generate(List<DairyListItem> dairyListItems)
        {
            DairyItemCollection dairyItemCollection = new DairyItemCollection();

            if (dairyListItems != null)
            {
                foreach (DairyListItem item in dairyListItems)
                {
                    dairyItemCollection.Add(
                               DairyItem.Create(
                                         item.ItemID,
                                         item.PriorityID,
                                         item.StatusID,
                                         item.DateID,
                                         item.ItemTitle,
                                         item.ItemContent));
                }
            }

            return dairyItemCollection;
        }
    }
}
