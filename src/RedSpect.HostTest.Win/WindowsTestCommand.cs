using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared;
using System.Windows.Input;
using RedSpect.Shared.Command;

namespace RedSpect.HostTest.Win
{
    public class WindowsTestCommand : CommandGroupBase, IInspectorCommandGroup
    {

        public WindowsTestCommand()
        {
            Initialize();
        }

        public override string Name
        {
            get { return "WindowsTest"; }
        }

        public override void Test()
        {
            Injection.WriteForm("Message from outer application.");
        }

        [Command("WriteValueOfX")]
        public void WriteValueOfX()
        {
            Injection.WriteForm(string.Format("The value of X is {0}", Injection.X));
        }

    }
}
