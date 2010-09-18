using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMBookStore.Model;

namespace MVVMBookStore.ViewModel
{
    public class AllBooksViewModel : ViewModelBase, IAllBooksViewModel
    {
        private BookModel _bookModel;

        public ObservableCollection<Book> AllBooks
        {
            get
            {
                return _bookModel.Books;
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