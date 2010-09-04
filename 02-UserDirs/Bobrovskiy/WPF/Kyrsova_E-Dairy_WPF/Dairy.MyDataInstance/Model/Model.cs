using System;

namespace Model
{
    /// <summary>
    /// Enumeration for tables in database
    /// all table must be added here
    /// Here can be add a name to access other stored procedure
    /// in database that not connected with one of the table it can be
    /// some statistic or etc.
    /// </summary>
    public enum TableList
    {
        DiaryListItem,
        Priority,
        ItemStatus,
        DiaryDate,
        Statistic
    }

    /// <summary>
    /// Represents DairyListItem database table model 
    /// </summary>
    public class DairyListItem
    {
        #region fields
        // itemID
        private int itemID = 0;
        // priorityID
        private int priorityID = 0;
        // statusID
        private int statusID = 0;
        // dateID
        private int dateID = 0;
        // itemTitle
        private string itemTitle = string.Empty;
        // itemContent
        private string itemContent = string.Empty;
        #endregion

        #region Properies

        /// <summary>
        /// Gets or sets ItemID
        /// </summary>
        public int ItemID
        {
            get { return itemID; }
            set
            {
                if (itemID == value) { return; }
                itemID = value;
            }
        }

        /// <summary>
        /// Gets or sets PriorityID
        /// </summary>
        public int PriorityID
        {
            get { return priorityID; }
            set
            {
                if (priorityID == value) { return; }
                priorityID = value;
            }
        }

        /// <summary>
        /// Gets or sets StatusID
        /// </summary>
        public int StatusID
        {
            get { return statusID; }
            set
            {
                if (statusID == value) { return; }
                statusID = value;
            }
        }

        /// <summary>
        /// Gets or sets DateID
        /// </summary>
        public int DateID
        {
            get { return dateID; }
            set
            {
                if (dateID == value) { return; }
                dateID = value;
            }
        }

        /// <summary>
        /// Gets or sets ItemTitle
        /// </summary>
        public string ItemTitle
        {
            get { return itemTitle; }
            set
            {
                if (itemTitle == value) { return; }
                itemTitle = value;
            }
        }

        /// <summary>
        /// Gets or sets ItemContent
        /// </summary>
        public string ItemContent
        {
            get { return itemContent; }
            set
            {
                if (itemContent == value) { return; }
                itemContent = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// Represents DairyDate database table model 
    /// </summary>
    public class DairyDateItem
    {
        #region fields

        // dateID
        private int dateID;
        // date
        private DateTime date = DateTime.Now;

        #endregion

        #region Properies

        /// <summary>
        /// Gets or sets DateID
        /// </summary>
        public int DateID
        {
            get { return dateID; }
            set
            {
                if (dateID == value) { return; }
                dateID = value;
            }
        }

        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date == value) { return; }
                date = value;
            }
        }

        #endregion
    }

    /// <summary>
    /// StatusPriorityItem used for Priority and Status database tables
    /// tables have the same structure no need to make two model  
    /// </summary>
    public class StatusPriorityItem
    {
        #region fields

        // ID
        private int id;
        // Name
        private string name;

        #endregion

        #region Properies

        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set
            {
                if (id == value) { return; }
                id = value;
            }
        }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) { return; }
                name = value;
            }
        }

        #endregion
    }

}//namespace
