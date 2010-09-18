using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MVVMBookStore.Model
{
    public class BookModel
    {
        private ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get
            {
                return _books;
            }
        }

        public void ClearBookList()
        {
            _books.Clear();
        }

        public void LoadBookList()
        {
            _books = new ObservableCollection<Book>();
            _books.Add(new Book {Name = "WPF For Professionals", Author = "McDonalds"});
            _books.Add(new Book { Name = "GoF", Author = "G. Buch" });
        }
    }
}