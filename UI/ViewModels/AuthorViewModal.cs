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
    public class AuthorViewModel : ViewModel
    {
        private IAuthor _author;
        public IAuthor Author
        {
            get => _author;
        }

        public AuthorViewModel(IAuthor author)
        {
            _author = author;
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

        [Required(ErrorMessage = "Imię jest wymagane")]
        public string FirstName
        {
            get => _author.FirstName;
            set
            {
                _author.FirstName = value;
                Validate();
                OnPropertyChanged("FirstName");
            }
        }
        
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string LastName
        {
            get => _author.LastName;
            set
            {
                _author.LastName = value;
                Validate();
                OnPropertyChanged("LastName");
            }
        }

        [Required(ErrorMessage = "Kraj jest wymagany")]
        public string Country
        {
            get => _author.Country;
            set
            {
                _author.Country = value;
                Validate();
                OnPropertyChanged("Country");
            }
        }


    }
}
