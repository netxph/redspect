using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared.Connection;

namespace RedSpect.Shared
{
    public class ProbeFactory
    {

        static ProbeFactory()
        { 
            //register components
            Connections = new Dictionary<string, IProbeConnection>();
            registerConnection(new IPCConnection());
            registerConnection(new TCPConnection());
        }

        private static void registerConnection(IProbeConnection connection)
        {
            Connections.Add(connection.Name.ToLower(), connection);
        }

        public static Dictionary<string, IProbeConnection> Connections { get; set; }

        public static ICommandRunner Create(string connectionId, string[] arguments)
        {
            connectionId = string.Format("{0}connection", connectionId);

            return Connections[connectionId].Create(arguments);
        }

    }

    
}