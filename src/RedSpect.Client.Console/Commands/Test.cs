using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.ComponentModel;
using System.Windows.Input;
using RedSpect.Shared.Interfaces;

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
            List<string> messages = new List<string>((IEnumerable<string>)message);

            foreach (var msg in messages)
            {
                System.Console.WriteLine(msg);
            }
        }

        [Command("TestConnect")]
        public void TestConnect(object args)
        {
            IInspectorService inspector = Activator.GetObject(typeof(IInspectorService), "ipc://Diagnostics/InspectorService") as IInspectorService;
            System.Console.WriteLine(inspector.HostDetails());
        }

        [Command("TestCommandSet")]
        public void TestCommandSet(object args)
        {
            IInspectorService inspector = Activator.GetObject(typeof(IInspectorService), "ipc://Diagnostics/InspectorService") as IInspectorService;
            inspector.TestCommandSet("WindowsTest");
        }

    }
}
