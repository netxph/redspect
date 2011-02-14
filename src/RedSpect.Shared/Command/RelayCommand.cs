using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;

namespace RedSpect.Shared.Contracts
{
    public class RelayCommand : CommandDetail, ICommand
    {
        readonly Func<object, ActionResult> _execute;
        readonly Predicate<object> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add {  }
            remove {  }
        }

        public delegate void ExecuteDelegate(object parameter);

        public RelayCommand(Func<object, ActionResult> execute)
            : this(execute, null)
        {

        }

        public RelayCommand(Func<object, ActionResult> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        public virtual void OnCanExecuteChanged(object sender, EventArgs e)
        {
        }
        
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public ActionResult Execute(object parameter)
        {
            return _execute(parameter);
        }

        
        
    }
}
