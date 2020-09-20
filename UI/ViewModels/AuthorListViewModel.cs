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
    class AuthorListViewModel : ViewModel
    {
        public ObservableCollection<AuthorViewModel> Authors { get; set; } = new ObservableCollection<AuthorViewModel>();
        private ListCollectionView _listCollectionView;
        Settings settings = new Settings();

        private Commands _filterData;
        public Commands FilterData { get => _filterData; }
        public String FilterString { get; set; }

        private AuthorViewModel _changedAuthor;
        public AuthorViewModel ChangedAuthor
        {
            get => _changedAuthor;
            set
            {
                _changedAuthor = value;
                OnPropertyChanged(nameof(ChangedAuthor));
            }
        }

        private AuthorViewModel _selectedAuthor;
        public AuthorViewModel SelectedAuthor
        {
            get => _selectedAuthor;
            set
            {
                _changedAuthor = value;
                _selectedAuthor = value;
                OnPropertyChanged(nameof(SelectedAuthor));
            }
        }

        private Commands _saveAuthorCommand;
        public Commands SaveAuthorCommand
        {
            get => _saveAuthorCommand;
        }
        
        private Commands _deleteAuthorCommand;
        public Commands DeleteAuthorCommand
        {
            get => _deleteAuthorCommand;
        }
        

        private Commands _addAuthorCommand;
        public Commands AddAuthorCommand
        {
            get => _addAuthorCommand;
        }

        



        public AuthorListViewModel()
        {
            OnPropertyChanged("Authors");
            GetAllAuthors();
            _listCollectionView = (ListCollectionView)CollectionViewSource.GetDefaultView(Authors);
            _filterData = new Commands(param => this.FilterAuthors());
            _saveAuthorCommand = new Commands(param => this.SaveAuthor(), param => this.CanSaveAuthor());
            _addAuthorCommand = new Commands(param => this.AddAuthor());
            _deleteAuthorCommand = new Commands(param => this.DeleteAuthor(), param => this.CanSaveAuthor());
        }

        private void GetAllAuthors()
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
            foreach(IAuthor author in businessLogic.Authors)
            {
                Authors.Add(new AuthorViewModel(author));
            }
        }

        private void FilterAuthors()
        {
            if (string.IsNullOrEmpty(FilterString))
            {
                _listCollectionView.Filter = null;
            }
            else
            {
                _listCollectionView.Filter = authorModel => (((AuthorViewModel)authorModel).LastName + " " + ((AuthorViewModel)authorModel).FirstName).Contains(FilterString);
            }
        }


        private void SaveAuthor()
        {
            if (!Authors.Contains(ChangedAuthor))
            {
                Authors.Add(ChangedAuthor);
            }
        }
        
        private void DeleteAuthor()
        {
            if (Authors.Contains(ChangedAuthor))
            {
                Authors.Remove(ChangedAuthor);
            }
        }

        private bool CanSaveAuthor()
        {
            if (ChangedAuthor != null && !ChangedAuthor.HasErrors)
            {
                return true;
            }
            return false;
        }

        private void AddAuthor()
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

            IAuthor author = businessLogic.CreateAuthor();
            ChangedAuthor = new AuthorViewModel(author);
            ChangedAuthor.Validate();
        }

        private bool CanAddAuthor()
        {
          
            return true;
        }
    }
}
