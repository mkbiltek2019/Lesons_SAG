﻿using System;
using System.Collections;
using Model;

namespace Dairy.MyDataInstance.DataProvider.Resources
{
    /// <summary>
    /// Bind database table names to stored procedures
    /// </summary>

    //TODO: refactor this 

    public struct StoredProcedureParametriser
    {
        public string SpName;
        public object[] SpParametersValues;

        public StoredProcedureParametriser(string spName, object[] spParametersValues)
        {
            SpName = spName;
            SpParametersValues = spParametersValues;
        }
    } 

    public static class Resources
    {
        public static Hashtable CreateInsertSPList()
        {
            //Hashtable spList1 = new Hashtable();

            //object[] param = new object[]
            //                             {
            //                                  new ParameterItem()
            //                                   {
            //                                       ParameterName = @"Date",
            //                                       ParameterValue = DateTime.Now
            //                                   }
            //                             };

            //spList1.Add(TableList.DiaryDate, new StoredProcedureParametriser()
            //                                     {
            //                                         SpName = "InsertDairyDate_SP",
            //                                         SpParametersValues = param
            //                                     });

            ////(spList1[TableList.DiaryDate]).



            Hashtable spList = new Hashtable();

            spList.Add(TableList.DiaryDate, @"InsertDairyDate_SP");
            spList.Add(TableList.ItemStatus, @"InsertItemStatus_SP");
            spList.Add(TableList.Priority, @"InsertPriority_SP");
            spList.Add(TableList.DiaryListItem, @"InsertDairyListItem_SP");
            return spList;
        }

        public static Hashtable CreateSelectSPList()
        {
            Hashtable spList = new Hashtable();

            spList.Add(TableList.DiaryDate, @"SelectDairyDate_SP");
            spList.Add(TableList.ItemStatus, @"SelectItemStatus_SP");
            spList.Add(TableList.Priority, @"SelectPriority_SP");
            spList.Add(TableList.DiaryListItem, @"SelectDairyListItemByDateID_SP");

            return spList;
        }

        public static Hashtable CreateSelectByIDSPList()
        {
            Hashtable spList = new Hashtable();

            spList.Add(TableList.DiaryDate, @"SelectDairyDateByDateID_SP");
            spList.Add(TableList.ItemStatus, @"SelectItemStatusByID_SP");
            spList.Add(TableList.Priority, @"SelectPriorityByID_SP");
            spList.Add(TableList.DiaryListItem, @"SelectDairyListItemByDateID_SP");

            return spList;
        }

        public static Hashtable CreateSelectByNameSPList()
        {
            Hashtable spList = new Hashtable();

            spList.Add(TableList.DiaryDate, @"SelectDairyDateByDate_SP");
            spList.Add(TableList.ItemStatus, @"SelectItemStatusByName_SP");
            spList.Add(TableList.Priority, @"SelectPriorityByName_SP");
            spList.Add(TableList.DiaryListItem, @"SelectDairyListItemByDateID_SP");

            return spList;
        }

        public static Hashtable CreateUpdateSPList()
        {
            Hashtable spList = new Hashtable();

            spList.Add(TableList.DiaryDate, @"UpdateDairyDate_SP");
            spList.Add(TableList.ItemStatus, @"UpdateItemStatus_SP");
            spList.Add(TableList.Priority, @"UpdatePriority_SP");
            spList.Add(TableList.DiaryListItem, @"UpdateDairyListItemByListItemID_SP");

            return spList;
        }

        public static Hashtable CreateDeleteSPList()
        {
            Hashtable spList = new Hashtable();

            spList.Add(TableList.DiaryDate, @"DeleteDairyDateByID_SP");
            spList.Add(TableList.ItemStatus, @"DeletePriorityByID_SP");
            spList.Add(TableList.Priority, @"DeletePriorityByID_SP");
            spList.Add(TableList.DiaryListItem, @"DeleteDiaryListItemByListItemID_SP");

            return spList;
        }

    }

}
