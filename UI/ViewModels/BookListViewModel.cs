using Siuchninski.PWBooksCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UI.Properties;

namespace Siuchninski.PWBooksCatalog.UI.ViewModels
{
    class BookListViewModel : ViewModel
    {
        public ObservableCollection<BookViewModel> Books { get; set; } = new ObservableCollection<BookViewModel>();
        private ListCollectionView _listCollectionView;
        Settings settings = new Settings();

        private Commands _filterData;
        public Commands FilterData { get => _filterData; }
        public String FilterString { get; set; }

        private BookViewModel _changedBook;
        public BookViewModel ChangedBook
        {
            get => _changedBook;
            set
            {
                _changedBook = value;
                OnPropertyChanged(nameof(ChangedBook));
            }
        }

        private BookViewModel _selectedBook;
        public BookViewModel SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                _changedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        private Commands _saveBookCommand;
        public Commands SaveBookCommand
        {
            get => _saveBookCommand;
        }
        

        private Commands _addBookCommand;
        public Commands AddBookCommand
        {
            get => _addBookCommand;
        }

        private Commands _deleteBookCommand;
        public Commands DeleteBookCommand
        {
            get => _deleteBookCommand;
        }

        



        public BookListViewModel()
        {
            OnPropertyChanged("Books");
            GetAllBooks();
            _listCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(Books);
            _filterData = new Commands(param => this.FilterBooks());
            _saveBookCommand = new Commands(param => this.SaveBook(), param => this.CanSaveBook());
            _addBookCommand = new Commands(param => this.AddNewBook());
            _deleteBookCommand = new Commands(param => this.DeleteBook(), param => this.CanSaveBook());
        }

        private void GetAllBooks()
        {
            Settings settings = new Settings();
            BL.BL businessLogic = null;
            try
            {
                businessLogic = new BL.BL(settings.DAO);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Błąd wczytywania danych");
            }

            List<IAuthor> authors = (List<IAuthor>)businessLogic.Authors;
            foreach(IBook book in businessLogic.Books)
            {
                Books.Add(new BookViewModel(book, authors));
            }
        }

        private void FilterBooks()
        {
            if (string.IsNullOrEmpty(FilterString))
            {
                _listCollectionView.Filter = null;
            }
            else
            {
                _listCollectionView.Filter = bookModel => ((BookViewModel)bookModel).Title.Contains(FilterString);
            }
        }


        private void SaveBook()
        {
            if (!Books.Contains(ChangedBook))
            {
                Books.Add(ChangedBook);
            }
        }

        private bool CanSaveBook()
        {
            if (ChangedBook != null && !ChangedBook.HasErrors)
            {
                return true;
            }
            return false;
        }

        private void AddNewBook()
        {
            Settings settings = new Settings();
            BL.BL businessLogic = null;
            try
            {
                businessLogic = new BL.BL(settings.DAO);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Błąd wczytywania danych");
            }

            IBook book = businessLogic.CreateBook();
            ChangedBook = new BookViewModel(book, (List<IAuthor>)businessLogic.Authors);
            ChangedBook.Validate();
        }

       
         private void DeleteBook()
        {
            Books.Remove(ChangedBook);
        }
    }
}
