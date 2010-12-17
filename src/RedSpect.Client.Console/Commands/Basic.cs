using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.ComponentModel;
using System.Windows.Input;

namespace RedSpect.Client.Console.Commands
{
    public class Basic : ICommandSet
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
    }
}
