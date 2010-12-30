using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using RedSpect.Shared.Interfaces;

namespace RedSpect.Client.Console.Commands
{
    public class Basic : ICommandGroup
    {

        const string COMMAND_SET_NAME = "Basic";

        public string Name
        {
            get { return COMMAND_SET_NAME; }
        }

        public Dictionary<string, ICommand> Commands
        {
            get { throw new NotImplementedException(); }
        }

        public void Test()
        {
            throw new NotImplementedException();
        }
    }
}
