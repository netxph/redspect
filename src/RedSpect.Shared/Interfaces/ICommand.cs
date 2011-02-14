using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Contracts;

namespace RedSpect.Shared.Interfaces
{
    public interface ICommand
    {

        event EventHandler CanExecuteChanged;
        bool CanExecute(object parameter);
        ActionResult Execute(object parameter);

    }
}
