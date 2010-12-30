using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting;
using RedSpect.Shared.Interfaces;

namespace RedSpect.Shared
{
    public class ApplicationProbe
    {

        private static Dictionary<string, IInspectorCommand> _inspectorCommands = new Dictionary<string, IInspectorCommand>();

        public static Dictionary<string, IInspectorCommand> InspectorCommands
        {
            get { return _inspectorCommands; }
        }

        public static void RegisterCommands(IInspectorCommand commandSet)
        {
            _inspectorCommands.Add(commandSet.Name, commandSet);
        }

        public static void Start()
        {
            BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();

            IDictionary properties = new Hashtable();
            properties["portName"] = "Diagnostics";
            properties["authorizedGroup"] = "Everyone";

            ChannelServices.RegisterChannel(new IpcChannel(properties, clientProvider, serverProvider), false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(InspectorService), "InspectorService", WellKnownObjectMode.Singleton);
        }

    }
}
