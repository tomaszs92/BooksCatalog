using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Siuchninski.PWBooksCatalog.UI.ViewModels
{
    public class Commands : ICommand
    {
        private Action<object> _exec;
        private Predicate<object> _canExec;

        public Commands(Action<object> exec)
        {
            _exec = exec;
        }

        public Commands(Action<object> exec, Predicate<object> canExec)
        {
            _exec = exec;
            _canExec = canExec;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if(_canExec != null)
            {
                return _canExec(parameter);
            }
            return true;
        }

        public void Execute(object parameter)
        {
            if(_exec != null)
            {
                _exec(parameter);
            }
        }

       
    }
}
