using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.ComponentModel;
using System.Windows.Input;

namespace RedSpect.Client.Console.Commands
{
    public class Test : CommandSetBase
    {
        const string COMMAND_SET_NAME = "Test";

        public override string Name
        {
            get { return COMMAND_SET_NAME; }
        }

        [Command("Say")]
        public void Say(object message)
        {
            System.Console.WriteLine(message.ToString());
        }
    }
}
