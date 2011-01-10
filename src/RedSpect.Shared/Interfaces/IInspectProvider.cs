using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Command;

namespace RedSpect.Shared.Interfaces
{
    public interface IInspectProvider
    {

        string HostDetails();
        void TestCommandSet(string name);
        ActionResult Execute(string commandName, object parameter);
        bool ContainsCommand(string commandName);
        ActionResult ExecuteScript(string command);
    }
}
