using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace RedSpect.Shared.Interfaces
{
    public interface IInspectProvider
    {

        string HostDetails();
        void TestCommandSet(string name);
        void Execute(string commandName, object parameter);
        bool ContainsCommand(string commandName);
    }
}
