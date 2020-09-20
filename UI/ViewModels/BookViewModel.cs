using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siuchninski.PWBooksCatalog.Core;
using Siuchninski.PWBooksCatalog.Interfaces;

namespace Siuchninski.PWBooksCatalog.UI.ViewModels
{
    public class BookViewModel : ViewModel
    {
        private IBook _book;
        public IBook Book
        {
            get => _book;
        }

        private ObservableCollection<IAuthor> _authors;
        public ObservableCollection<IAuthor> Authors
        {
            get => _authors;
        }

        public BookViewModel(IBook book, List<IAuthor> authors)
        {
            _book = book;
            _authors = new ObservableCollection<IAuthor>(authors);
        }

        public void Validate()
        {
            ValidationContext validationContext = new ValidationContext(this, null, null);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            foreach(var e in _errors.ToList())
            {
                if(validationResults.All(r => r.MemberNames.All(m => m != e.Key)))
                {
                    _errors.Remove(e.Key);
                    OnErrorChange(e.Key);
                }
            }

            var q = from result in validationResults
                    from name in result.MemberNames
                    group result by name into g
                    select g;

            foreach(var prop in q)
            {
                var messages = prop.Select(result => result.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);
                OnErrorChange(prop.Key);
            }
        }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        public string Title
        {
            get => _book.Title;
            set
            {
                _book.Title = value;
                Validate();
                OnPropertyChanged("Title");
            }
        }


        [Required(ErrorMessage = "Autor jest wymagany")]
        public IAuthor Author
        {
            get => _book.Author;
            set
            {
                _book.Author = value;
                Validate();
                OnPropertyChanged("Author");
            }
        }


        [Required(ErrorMessage = "Liczba stron jest wymagana")]
        public int Pages
        {
            get => _book.Pages;
            set
            {
                _book.Pages = value;
                Validate();
                OnPropertyChanged("Pages");
            }
        }


        [Required(ErrorMessage = "Typ jest wymagany")]
        public BookType Type
        {
            get => _book.Type;
            set
            {
                _book.Type = value;
                Validate();
                OnPropertyChanged("Type");
            }
        }


    }
}
