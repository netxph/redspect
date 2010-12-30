using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared;

namespace RedSpect.HostTest.Win
{
    public class TestCommand : IInspectorCommand
    {
        public string Name
        {
            get { return "WindowsTest"; }
        }

        public void Test()
        {
            Injection.WriteForm("Message from outer application.");
        }
    }
}
