using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting;
using RedSpect.Shared.Contracts;

namespace RedSpect.Shared.Providers
{
    public class IPCProbeProvider : IProbeProvider
    {
        #region Declarations

        const string PROVIDER_NAME = "IPCProbeProvider";
        
        bool _isStarted = false;

        #endregion

        public string Name
        {
            get { return PROVIDER_NAME; }
        }

        public void Start(IDictionary<string, string> properties, List<Type> customServices)
        {

            var tcpChannel = ChannelServices.RegisteredChannels.FirstOrDefault(channel => channel is IpcChannel);

            if (tcpChannel == null)
            {
                createIpcChannel(properties);
            }
            
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(DefaultCommandRunner), "InspectorService", WellKnownObjectMode.Singleton);
            
            _isStarted = true;
        }

        private void createIpcChannel(IDictionary<string, string> properties)
        {
            BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();

            IDictionary ipcProperties = new Hashtable();
            ipcProperties["portName"] = properties.GetProperty("portName", "Diagnostics");
            ipcProperties["authorizedGroup"] = properties.GetProperty("authorizedGroup", "Everyone");

            ChannelServices.RegisterChannel(new IpcChannel(ipcProperties, clientProvider, serverProvider), false);
        }

        public void Stop()
        {
        }

        public bool IsStarted
        {
            get { return _isStarted; }
        }

    }
}
