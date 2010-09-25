using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using TheatreTicketBooking.Client.Model;
using System.Collections.ObjectModel;

namespace TheatreTicketBooking.Client.ViewModel
{
    public class ViewModel:: ViewModelBase, IAllBooksViewModel
    {
        private PremiereModel _premiereModel;

        public ObservableCollection<Premiere> AllPremiere
        {
            get
            {
                return _premiereModel.Books;
            }
        }

        public AllBooksViewModel()
        {
            _bookModel = new BookModel();

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadBooksCommand = new RelayCommand(ShowBookList);
            ClearBookListCommand = new RelayCommand(ClearBookList);
        }

        public RelayCommand LoadBooksCommand { get; set; }
        public RelayCommand ClearBookListCommand { get; set; }

        public void ClearBookList()
        {
            _bookModel.ClearBookList();
            RaisePropertyChanged("AllBooks");
        }

        public void ShowBookList()
        {
            _bookModel.LoadBookList();
            RaisePropertyChanged("AllBooks");
        } 
    }
}
