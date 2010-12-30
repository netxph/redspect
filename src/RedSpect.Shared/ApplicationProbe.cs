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

        private static Dictionary<string, IInspectorCommandGroup> _inspectorCommands = new Dictionary<string, IInspectorCommandGroup>();

        public static Dictionary<string, IInspectorCommandGroup> InspectorCommands
        {
            get { return _inspectorCommands; }
        }

        public static void RegisterCommands(IInspectorCommandGroup commandGroup)
        {
            _inspectorCommands.Add(commandGroup.Name, commandGroup);
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
