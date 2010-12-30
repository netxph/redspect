using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using System.Reflection;
using System.IO;

namespace RedSpect.Shared
{
    public class InspectorService : MarshalByRefObject, IInspectorService
    {

        public string HostDetails()
        {
            return string.Format("{0} => {1}", Environment.MachineName, Path.GetFileName(Assembly.GetEntryAssembly().Location));
        }

        public void TestCommandSet(string name)
        {
            ApplicationProbe.InspectorCommands[name].Test();
        }
    }
}
