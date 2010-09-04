using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        //  Database worker
        private TableAssemblyWorker databaseWorker = new TableAssemblyWorker();
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
            if (current == null)
            {
                return;
            }

            databaseWorker.ListItem = databaseWorker.ListItem = new DairyListItem()
            {
                ItemID = current.ItemID
            };

            databaseWorker.Delete();

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
                //  if (createCommand == null)
                // {
                createCommand =
                    new RelayCommand(x => CreateDairyItem());
                // }
                return createCommand;
            }
        }

        // Creates DairyItem
        void CreateDairyItem()
        {
            _dairyItemCollection.Insert(0, new DairyItem());
            Current = _dairyItemCollection[0];
            createCommand.RaiseCanExecuteChanged();

            databaseWorker.ListItem = new DairyListItem()
                                              {
                                                  PriorityID = current.PriorityID,
                                                  StatusID = current.StatusID,
                                                  DateID = 1,
                                                  ItemTitle = current.ItemTitle,
                                                  ItemContent = current.ItemContent
                                              };

            databaseWorker.DateItem = new DairyDateItem()
            {
                Date = selectDate,
                DateID = 0
            };

            databaseWorker.Insert();

            CreateDairyItemList();
        }

        #endregion

        #region Commit

        RelayCommand commitCommand;

        /// <summary>
        /// Delete this DairyItem
        /// </summary>
        public ICommand CommitCommand
        {
            get
            {
                if (commitCommand == null)
                {
                    commitCommand =
                        new RelayCommand(x => CommitData());
                }
                return commitCommand;
            }
        }

        // Creates DairyItem
        void CommitData()
        {
            databaseWorker.DateItem = new DairyDateItem()
            {
                Date = SelectDateCommand,
                DateID = 0
            };

            foreach (DairyItem item in ItemCollection)
            {
                databaseWorker.ListItem = new DairyListItem()
                {
                    ItemID = item.ItemID,
                    PriorityID = item.PriorityID,
                    StatusID = item.StatusID,
                    DateID = item.DateID,
                    ItemTitle = item.ItemTitle,
                    ItemContent = item.ItemContent
                };

                databaseWorker.Update();
            }

            commitCommand.RaiseCanExecuteChanged();
        }

        #endregion  

        #region SelectDate

        private DateTime selectDate = DateTime.Now;
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
            databaseWorker.DateItem = new DairyDateItem()
                                         {
                                             Date = selectDate,
                                             DateID = 0
                                         };

            ItemCollection = DairyItemCollection.Generate(
                                                 databaseWorker.Select());
        }

        #endregion

        #region Statistic 

        #region Today
        private string statisticToday = "Today: 0";
        /// <summary>
        /// On SelectDate action ComboBoxSelectedItem
        /// </summary>
        public string StatisticToday
        {
            get
            {
                return statisticToday;
            }
            set
            {
                if (statisticToday != value)
                {
                    statisticToday = value;
                    UpdateStatistic();
                    RaisePropertyChanged("StatisticToday");
                }
            }
        }

        // UpdateStatistic 
        void UpdateStatistic()
        {
            databaseWorker.DateItem = new DairyDateItem()
            {
                Date = DateTime.Now,
                DateID = 0
            };

            statisticToday = string.Format("Today: {0}", 1);

            //ItemCollection = DairyItemCollection.Generate(
            //databaseWorker.Select());
        }

        #endregion

        #region Tomorrow

        private string statisticTomorrow = "Tomorrow: 0";
        /// <summary>
        /// On SelectDate action ComboBoxSelectedItem
        /// </summary>
        public string StatisticTomorrow
        {
            get
            {
                return statisticTomorrow;
            }
            set
            {
                if (statisticTomorrow != value)
                {
                    statisticTomorrow = value;
                    UpdateStatisticForTommorow();
                    RaisePropertyChanged("StatisticTomorrow");
                }
            }
        }

        // UpdateStatistic 
        void UpdateStatisticForTommorow()
        {
            databaseWorker.DateItem = new DairyDateItem()
            {
                Date = DateTime.Now.AddDays(1),
                DateID = 0
            };

            statisticToday = string.Format("Tomorrow: {0}", 1);

            //ItemCollection = DairyItemCollection.Generate(
            //databaseWorker.Select());
        }

        #endregion

        #region Declined

        private string statisticDeclined = "Declined: 0";
        /// <summary>
        /// On  action 
        /// </summary>
        public string StatisticDeclined
        {
            get
            {
                return statisticDeclined;
            }
            set
            {
                if (statisticDeclined != value)
                {
                    statisticDeclined = value;
                    UpdateStatisticForDeclined();
                    RaisePropertyChanged("StatisticDeclined");
                }
            }
        }

        // UpdateStatistic 
        void UpdateStatisticForDeclined()
        {
            databaseWorker.DateItem = new DairyDateItem()
            {
                Date = DateTime.Now,
                DateID = 0
            };

            statisticToday = string.Format("Declined: {0}", 1);

            //ItemCollection = DairyItemCollection.Generate(
            //databaseWorker.Select());
        }

        #endregion

        #region Done

        private string statisticDone = "Done: 0";
        /// <summary>
        /// On action 
        /// </summary>
        public string StatisticDone
        {
            get
            {
                return statisticDone;
            }
            set
            {
                if (statisticDone != value)
                {
                    statisticDone = value;
                    UpdateStatisticForStatisticDone();
                    RaisePropertyChanged("StatisticDone");
                }
            }
        }

        // UpdateStatistic 
        void UpdateStatisticForStatisticDone()
        {
            databaseWorker.DateItem = new DairyDateItem()
            {
                Date = DateTime.Now,
                DateID = 0
            };

            statisticToday = string.Format("Done: {0}", 1);

            //ItemCollection = DairyItemCollection.Generate(
            //databaseWorker.Select());
        }

        #endregion


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