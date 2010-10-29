using System;
using Dairy.MyDataInstance;
using Model;
using System.Collections.Generic;

namespace Instance.DataProvider
{
    public static class ParameterProvider
    {
        /// <summary>
        /// ParameterProvider is the resource with
        /// parameters for stored procedure
        /// Ettension!!!! 
        /// Parameter names must be the same like
        /// stored procedure parameter name other wise
        /// you will get some error 
        /// 
        /// </summary>  

        public static List<ParameterItem> GetParameterListForSelectDairyListItem(DairyListItem dairyItem)
        {
            List<ParameterItem> parameterList = new List<ParameterItem>();

            if (dairyItem == null)
            {
                throw new Exception("GetParameterListForSelectDairyListItem(DairyListItem dairyItem) input parameter can't be null");
            }

            parameterList.Add(new ParameterItem()
            {
                ParameterName = "ItemID",
                ParameterValue = dairyItem.ItemID
            });

            parameterList.Add(new ParameterItem()
            {
                ParameterName = "PriorityID",
                ParameterValue = dairyItem.PriorityID
            });

            parameterList.Add(new ParameterItem()
            {
                ParameterName = "StatusID",
                ParameterValue = dairyItem.StatusID
            });

            parameterList.Add(new ParameterItem()
            {
                ParameterName = "DateID",
                ParameterValue = dairyItem.DateID
            });

            parameterList.Add(new ParameterItem()
            {
                ParameterName = "ItemTitle",
                ParameterValue = dairyItem.ItemTitle
            });

            parameterList.Add(new ParameterItem()
            {
                ParameterName = "ItemContent",
                ParameterValue = dairyItem.ItemContent
            });

            return parameterList;
        }

        public static List<ParameterItem> GetParameterListForDeleteDairyItem(int ID)
        {
            List<ParameterItem> parameterList = new List<ParameterItem>();

            if ((ID <0) && (ID > int.MaxValue))
            {
                throw new Exception("GetParameterListForDeleteDairyItem(int ID) input parameter can't be null");
            }

            parameterList.Add(new ParameterItem()
            {
                ParameterName = @"ItemID",
                ParameterValue = ID
            });

            return parameterList;
        }

        public static List<ParameterItem> GetParameterListForInsertDairyDateItem(DairyDateItem dairyDateItem)
        {
            List<ParameterItem> parameterList = new List<ParameterItem>();

            if (dairyDateItem == null)
            {
                throw new Exception("GetParameterListForInsertDairyDateItem(DairyDateItem dairyDateItem) input parameter can't be null");
            }

            parameterList.Add(new ParameterItem()
            {
                ParameterName = @"Date",
                ParameterValue = dairyDateItem.Date
            });

            return parameterList;
        }

        public static List<ParameterItem> GetParameterListForInsertDairyListItem(DairyListItem dairyItem)
        {
            List<ParameterItem> parameterList = new List<ParameterItem>();

            if (dairyItem == null)
            {
                throw new Exception("GetParameterListForInsertDairyDateItem(DairyDateItem dairyDateItem) input parameter can't be null");
            }

            parameterList.Add(new ParameterItem()
            {
                ParameterName = @"PriorityID",
                ParameterValue = dairyItem.PriorityID
            });

            parameterList.Add(new ParameterItem()
            {
                ParameterName = @"StatusID",
                ParameterValue = dairyItem.StatusID
            });

             parameterList.Add(new ParameterItem()
            {
                ParameterName = @"DateID",
                ParameterValue = dairyItem.DateID
            });

            parameterList.Add(new ParameterItem()
            {
                ParameterName = @"ItemTitle",
                ParameterValue = dairyItem.ItemTitle
            });

            parameterList.Add(new ParameterItem()
            {
                ParameterName = @"ItemContent",
                ParameterValue = dairyItem.ItemContent
            });

            return parameterList;            
        }

    }//class

}//namespace
