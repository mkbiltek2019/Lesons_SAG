#region Copyright and License Information

// Fluent Ribbon Control Suite
// http://fluent.codeplex.com/
// Copyright © Degtyarev Daniel, Rikker Serg. 2009-2010.  All rights reserved.
// 
// Distributed under the terms of the Microsoft Public License (Ms-PL). 
// The license is available online http://fluent.codeplex.com/license

#endregion

using System.ComponentModel;
using System.Windows.Input;
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
        private readonly DairyItemCollection _dairyItemCollection = DairyItemCollection.Generate();
        // Current person
        private DairyItem current;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets current DairyItem
        /// </summary>
        public DairyItem Current
        {
            get { return current; }
            set
            {
                if (current == value) return;
                current = value;
                RaisePropertyChanged("Current");
            }
        }

        /// <summary>
        /// Gets DairyItem collection
        /// </summary>
        public DairyItemCollection ItemCollection
        {
            get { return _dairyItemCollection; }
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
            deleteCommand.RaiseCanExecuteChanged();
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