using System.ComponentModel;

namespace Mvvm.Model
{
    /// <summary>
    /// Represents DairyItem
    /// </summary>
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
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Fields

        // Date
        private string date = "03/04/10";
        // Title
        private string title;
        // Content
        private string content;
        // Priority
        private int priority;
        // Status
        private int status;

        #endregion

        #region Properies

        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public string Date
        {
            get { return date; }
            set
            {
                if (date == value) { return; }
                date = value;
                RaisePropertyChanged("Date");
            }
        }

        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title
        {
            get { return title; }
            set
            {
                if (title == value) { return; }
                title = value;
                RaisePropertyChanged("Title");
            }
        }

        /// <summary>
        /// Gets or sets Content
        /// </summary>
        public string Content
        {
            get { return content; }
            set
            {
                if (content == value) { return; }
                content = value;
                RaisePropertyChanged("Content");
            }
        }

        /// <summary>
        /// Gets or sets Priority
        /// </summary>
        public int Priority
        {
            get { return priority; }
            set
            {
                if (priority == value) { return; }
                priority = value;
                RaisePropertyChanged("Priority");
            }
        }

        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public int Status
        {
            get { return status; }
            set
            {
                if (status == value) { return; }
                status = value;
                RaisePropertyChanged("Status");
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates new DairyItem
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="title">Title</param>
        /// <param name="content">Content</param>
        /// /// <param name="priority">Priority</param>
        /// <param name="status">Status</param>
        /// <returns>DairyItem</returns>
        public static DairyItem Create(string date, string title, string content, int priority, int status)
        {
            DairyItem dairyItem = new DairyItem();
            dairyItem.date = date;
            dairyItem.title = title;
            dairyItem.content = content;
            dairyItem.priority = priority;
            dairyItem.status = status;
            return dairyItem;
        }

        #endregion
    }
}
