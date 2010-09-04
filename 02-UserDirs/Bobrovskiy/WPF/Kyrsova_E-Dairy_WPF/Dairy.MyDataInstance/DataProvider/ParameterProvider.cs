using System;
using Dairy.MyDataInstance;
using Model;

namespace Instance.DataProvider
{
    public static class ParameterProvider
    {
        public static ParameterItem InParam
        {
            get;
            set;
        }

        public static ParameterItem OutParam
        {
            get;
            set;
        }

        public static void SetInOutParam(DairyDateItem param)
        {
            InParam = new ParameterItem()
            {
                ParameterName = @"Date",
                ParameterValue = param.Date
            };

            OutParam = new ParameterItem()
            {
                ParameterName = @"result",
                ParameterValue = 0
            };
        }

        public static object[] GetParameterListForSelectDairyListItem(DairyListItem dairyItem)
        {
            if (dairyItem!=null)
            {
               return new object[]{
                   new ParameterItem()
                       {
                           ParameterName = @"ItemID",
                           ParameterValue = dairyItem.ItemID
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"PriorityID",
                           ParameterValue = dairyItem.PriorityID
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"StatusID",
                           ParameterValue = dairyItem.StatusID
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"DateID",
                           ParameterValue = dairyItem.DateID
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"ItemTitle",
                           ParameterValue = dairyItem.ItemTitle
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"ItemContent",
                           ParameterValue = dairyItem.ItemContent
                       }
               };
            }
            
            return  new object[]{
                   new ParameterItem()
                       {
                           ParameterName = @"ItemID",
                           ParameterValue = 0
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"PriorityID",
                           ParameterValue = 0
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"StatusID",
                           ParameterValue = 0
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"DateID",
                           ParameterValue = 0
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"ItemTitle",
                           ParameterValue = "none"
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"ItemContent",
                           ParameterValue = "none"
                       }
               };
        }     

        public static object[] GetParameterListForDeleteDairyItem(int ID)
        {
               return new object[]{
                   new ParameterItem()
                       {
                           ParameterName = @"ItemID",
                           ParameterValue = ID
                       }
               };
        }

        public static object[] GetParameterListForInsertDairyDateItem(DairyDateItem dairyDateItem)
        {
            if (dairyDateItem!=null)
            {
               return new object[]{
                   new ParameterItem()
                       {
                           ParameterName = @"Date",
                           ParameterValue = dairyDateItem.Date
                       }
               };
            }
            return new object[]{
                   new ParameterItem()
                       {
                           ParameterName = @"Date",
                           ParameterValue = DateTime.Now
                       }
               };
        }

        public static object[] GetParameterListForInsertDairyListItem(DairyListItem dairyItem)
        {
            if (dairyItem != null)
            {
                return new object[]{
                   new ParameterItem()
                       {
                           ParameterName = @"PriorityID",
                           ParameterValue = dairyItem.PriorityID
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"StatusID",
                           ParameterValue = dairyItem.StatusID
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"DateID",
                           ParameterValue = dairyItem.DateID
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"ItemTitle",
                           ParameterValue = dairyItem.ItemTitle
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"ItemContent",
                           ParameterValue = dairyItem.ItemContent
                       }
               };
            }

            return new object[]{
                   new ParameterItem()
                       {
                           ParameterName = @"PriorityID",
                           ParameterValue = 0
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"StatusID",
                           ParameterValue = 0
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"DateID",
                           ParameterValue = 0
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"ItemTitle",
                           ParameterValue = "none"
                       },
                   new ParameterItem()
                       {
                           ParameterName = @"ItemContent",
                           ParameterValue = "none"
                       }
               };
        }

    }//class

}//namespace
