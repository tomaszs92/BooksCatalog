using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siuchninski.PWBooksCatalog.UI.ViewModels
{
    public class ViewModel : INotifyDataErrorInfo, INotifyPropertyChanged

    {
        protected Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string property)
        {
            if (_errors.ContainsKey(property))
            {
                return _errors[property];
            }
            return null;
        }
        
        protected void DeleteErrors(string property)
        {
            if (_errors.ContainsKey(property))
            {
                _errors.Remove(property);
            }
        }

        protected void AddError(string property, string error)
        {
            List<string> propertyErrors = null;
            if (_errors.ContainsKey(property))
            {
                propertyErrors = _errors[property];
                propertyErrors.Add(error);
            }
            else
            {
                propertyErrors = new List<string>();
                propertyErrors.Add(error);
                _errors.Add(property, propertyErrors);
            }
        }

        protected void OnErrorChange(string property)
        {
            if(ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(property));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
