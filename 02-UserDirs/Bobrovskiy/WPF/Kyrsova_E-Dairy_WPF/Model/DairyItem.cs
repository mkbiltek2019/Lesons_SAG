using System.ComponentModel;

namespace Mvvm.Model
{ // the name in the Model must be the same like in database

    public class DairyItem : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // Raise PropertyChanged event
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Fields

        // itemID
        private int itemID = 1;
        // priorityID
        private int priorityID = 1;
        // statusID
        private int statusID = 1;
        // dateID
        private int dateID = 1;
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
                if (itemID == value)
                {
                    return;
                }

                itemID = value;
                RaisePropertyChanged("ItemID");
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
                if (priorityID == value)
                {
                    return;
                }

                priorityID = value;
                RaisePropertyChanged("PriorityID");
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
                if (statusID == value)
                {
                    return;
                }

                statusID = value;
                RaisePropertyChanged("StatusID");
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
                if (dateID == value)
                {
                    return;
                }

                dateID = value;
                RaisePropertyChanged("DateID");
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
                if (itemTitle == value)
                {
                    return;
                }

                itemTitle = value;
                RaisePropertyChanged("ItemTitle");
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
                if (itemContent == value)
                {
                    return;
                }

                itemContent = value;
                RaisePropertyChanged("ItemContent");
            }
        }

        #endregion 

        #region Methods

        /// <summary>
        /// Creates new DairyItem
        /// </summary>
        /// <param name="itemID">itemID</param>
        /// <param name="dateID">dateID</param>
        /// <param name="title">title</param>
        /// <param name="content">Content</param>
        /// /// <param name="priority">PripriorityIDrity</param>
        /// <param name="status">statusID</param>
        /// <returns>DairyItem</returns>
        public static DairyItem Create(int itemID,  int priorityID,
                                       int statusID, int dateID, string title,
                                       string content)
        {
            DairyItem dairyItem = new DairyItem();
            dairyItem.itemID = itemID;
            dairyItem.priorityID = priorityID;
            dairyItem.statusID = statusID;
            dairyItem.dateID = dateID;
            dairyItem.itemTitle = title;
            dairyItem.itemContent = content;
           
            return dairyItem;
        }

        #endregion
    }//class

}//namespace