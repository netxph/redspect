using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared.Command;

namespace RedSpect.Shared.Connection
{
    public class TCPConnection : IProbeConnection
    {
        const string CONNECTION_NAME = "TCPConnection";

        public string Name
        {
            get { return CONNECTION_NAME; }
        }

        public ICommandRunner Create(string[] properties)
        {
            var uri = new Uri(string.Format("tcp://{0}:{1}/{2}", properties.GetArgument(0, "localhost"), properties.GetArgument(1, "10999"), properties.GetArgument(2, "InspectorService")));

            return Activator.GetObject(typeof(ICommandRunner), uri.AbsoluteUri) as ICommandRunner;
        }
    }
}
