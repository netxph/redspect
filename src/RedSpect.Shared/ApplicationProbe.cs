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

        private static Dictionary<string, IInspectorCommandGroup> _inspectorCommands = new Dictionary<string,IInspectorCommandGroup>();
        private static IProbeProvider _probeProvider = null;
        private static List<Type> _customServices = new List<Type>();

        public static IProbeProvider ProbeProvider
        { 
            get 
            {
                return _probeProvider;
            }
        }

        public static Dictionary<string, IInspectorCommandGroup> InspectorCommands
        {
            get { return _inspectorCommands; }
        }

        public static void RegisterCommands(IInspectorCommandGroup commandGroup)
        {
            _inspectorCommands.Add(commandGroup.Name, commandGroup);
        }

        public static void RegisterCustomService(Type serviceType)
        {
            _customServices.Add(serviceType);
        }

        public static void Start<T>(IDictionary<string, string> properties) where T: IProbeProvider
        {
            _probeProvider = Activator.CreateInstance<T>();
            _probeProvider.Start(properties, _customServices);
        }

        public static void Stop()
        {
            if (ProbeProvider != null && ProbeProvider.IsStarted)
            {
                ProbeProvider.Stop();
            }
        }
        
    }
}
