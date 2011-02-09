using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;

namespace RedSpect.Shared.Providers
{
    public class TCPProbeProvider : IProbeProvider
    {

        #region Declarations

        const string PROVIDER_NAME = "TCPProbeProvider";

        bool _isStarted = false;

        #endregion

        public string Name
        {
            get { return PROVIDER_NAME; }
        }

        public void Start(IDictionary<string, string> properties)
        {
            var tcpChannel = ChannelServices.RegisteredChannels.FirstOrDefault(channel => channel is TcpChannel);

            if (tcpChannel == null)
            {
                createTcpChannel(properties);
            }

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(DefaultCommandRunner), "InspectorService", WellKnownObjectMode.Singleton);

            _isStarted = true;
        }

        private void createTcpChannel(IDictionary<string, string> properties)
        {
            TcpChannel tcpChannel = new TcpChannel(10999);
            ChannelServices.RegisterChannel(tcpChannel);
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
