using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared;
using System.Windows.Input;

namespace RedSpect.HostTest.Win
{
    public class TestCommand : IInspectorCommandGroup
    {
        public string Name
        {
            get { return "WindowsTest"; }
        }

        public void Test()
        {
            Injection.WriteForm("Message from outer application.");
        }


        public Dictionary<string, ICommand> Commands
        {
            get { throw new NotImplementedException(); }
        }
    }
}
