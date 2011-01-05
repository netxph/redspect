using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared.Command;

namespace RedSpect.Client.Console.Commands
{
    public class TestCommands : CommandGroupBase
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

        [Command("TestSet")]
        public void TestCommandSet(object args)
        {
            IInspectorService inspector = Activator.GetObject(typeof(IInspectorService), "ipc://Diagnostics/InspectorService") as IInspectorService;
            inspector.TestCommandSet("WindowsTest");
        }

        public override void Test()
        {
            throw new NotImplementedException();
        }
    }
}
