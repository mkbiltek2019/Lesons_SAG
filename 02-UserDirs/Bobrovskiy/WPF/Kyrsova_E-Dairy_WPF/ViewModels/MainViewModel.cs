using System;
using System.ComponentModel;
using System.Windows.Input;
using Dairy.MyDataInstance.DataProvider;
using Model;
using Mvvm.Comands;
using Mvvm.Model;

namespace Mvvm.ViewModels
{
    /// <summary>
    /// Represents main view model
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        // Raise PropertyChanged event
        void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Fields

        // All DairyItems
        private DairyItemCollection _dairyItemCollection = DairyItemCollection.Generate(null);
        // Current DairyItem
        private DairyItem current; 

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets current DairyItem
        /// </summary>
        public DairyItem Current
        {
            get
            {
                return current;
            }
            set
            {
                if (current == value) return;
                current = value;
                RaisePropertyChanged("Current");
                deleteCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets DairyItem collection
        /// </summary>
        public DairyItemCollection ItemCollection
        {
            get { return _dairyItemCollection; }
            set
            {
                if (_dairyItemCollection == value)
                {
                    return;
                }

                _dairyItemCollection = value;
                RaisePropertyChanged("ItemCollection");
            }
        }


        #endregion

        #region Commands

        #region Exit

        RelayCommand exitCommand;

        /// <summary>
        /// Exit from the application
        /// </summary>
        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                {
                    exitCommand = new RelayCommand(x => System.Windows.Application.Current.Shutdown());
                }
                return exitCommand;
            }
        }

        #endregion
        
        #region Delete

        RelayCommand deleteCommand;

        /// <summary>
        /// Delete this DairyItem
        /// </summary>
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand(
                        x => DeleteCurrentDairyItem(),
                        x => current != null);
                    
                }
                return deleteCommand;
            }
        }

        // Deletes current DairyItem
        void DeleteCurrentDairyItem()
        {
            if (current == null) return;
            DairyItem deleted = current;

            if (_dairyItemCollection.Count != 1)
            {
                int index = _dairyItemCollection.IndexOf(deleted);
                Current = _dairyItemCollection[index == 0 ? 1 : index - 1];
            }
            else
            {
                Current = null;
                deleteCommand.RaiseCanExecuteChanged();
            }

            _dairyItemCollection.Remove(deleted);
            
        }

        #endregion

        #region Create

        RelayCommand createCommand;

        /// <summary>
        /// Delete this DairyItem
        /// </summary>
        public ICommand CreateCommand
        {
            get
            {
                if (createCommand == null)
                {
                    createCommand = new RelayCommand(x => CreateDairyItem());

                }
                return createCommand;
            }
        }

        // Creates DairyItem
        void CreateDairyItem()
        {
            _dairyItemCollection.Insert(0, new DairyItem());
            Current = _dairyItemCollection[0];
            //deleteCommand.RaiseCanExecuteChanged();
            //-----------------
            //DairyListItem dairyListItem = new DairyListItem()
            //                                  {   ItemID  = current.ID,
            //                                      PriorityID = current.Priority,
            //                                      StatusID = 1,
            //                                      DateID = 1,
            //                                      ItemTitle = current.Title,
            //                                      ItemContent = current.Content
            //                                  };

            ////DairyDateItem dateItem = new DairyDateItem()
            ////                             {
            ////                                 Date = DateTime.Now,
            ////                                 DateID = 0
            ////                             };
            
            //TableController tabeController = new TableController();

            //tabeController.Insert(dairyListItem);

        }

        #endregion

        #region SelectDate

        private DateTime selectDate=DateTime.Now;
        /// <summary>
        /// On SelectDate action ComboBoxSelectedItem
        /// </summary>
        public DateTime SelectDateCommand
        {
            get
            {
                return selectDate;
            }
            set
            {
                if (selectDate != value)
                {
                  selectDate = value;
                  CreateDairyItemList();
                  RaisePropertyChanged("SelectDateCommand");
                } 
            }
        }

        // Creates DairyItemList from dataBase by selected Date
        void CreateDairyItemList()
        {
            DateTime day = Convert.ToDateTime("04.03.10");

            TableAssemblyWorker worker = new TableAssemblyWorker();
            DairyDateItem dateItem = new DairyDateItem()
                                         {
                                             Date = day,
                                             DateID = 0 
                                         };
            worker.DateItem = dateItem;

            ItemCollection = DairyItemCollection.Generate(worker.Select());
            
            //deleteCommand.RaiseCanExecuteChanged();

            //_dairyItemCollection.Insert(0, new DairyItem());
            //Current = _dairyItemCollection[0];
            //deleteCommand.RaiseCanExecuteChanged();
            //-----------------
            //DairyListItem dairyListItem = new DairyListItem()
            //{
            //    PriorityID = current.Priority,
            //    StatusID = 1,
            //    DateID = 1,
            //    ItemTitle = current.Title,
            //    ItemContent = current.Content
            //};

            //DairyDateItem dateItem = new DairyDateItem()
            //                             {
            //                                 Date = DateTime.Now,
            //                                 DateID = 0
            //                             };

            //TableController tabeController = new TableController();

            //tabeController.Insert(dairyListItem);

        }

        #endregion  

        #endregion

        #region Initialization

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainViewModel()
        {
            if (_dairyItemCollection.Count > 0) Current = _dairyItemCollection[0];
        }

        #endregion
    }
}