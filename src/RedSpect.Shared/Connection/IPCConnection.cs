using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared.Command;

namespace RedSpect.Shared.Connection
{
    public class IPCConnection : IProbeConnection
    {

        const string CONNECTION_NAME = "IPCConnection";

        public string Name
        {
            get { return CONNECTION_NAME; }
        }

        public ICommandRunner Create(string[] properties)
        {
            var uri = new Uri(string.Format("ipc://{0}/{1}", properties.GetArgument(0, "Diagnostics"), properties.GetArgument(1, "InspectorService")));

            return Activator.GetObject(typeof(ICommandRunner), uri.AbsoluteUri) as ICommandRunner;
        }
      
    }
}
