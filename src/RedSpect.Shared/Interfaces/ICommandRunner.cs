using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Contracts;

namespace RedSpect.Shared.Interfaces
{
    public interface ICommandRunner
    {

        string HostDetails();
        void TestCommandSet(string name);
        ActionResult Execute(string commandName, object parameter);
        bool ContainsCommand(string commandName);
        ActionResult ExecuteScript(string command);
        CommandDetail[] GetCommands();

    }
}
