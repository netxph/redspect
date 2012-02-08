using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using RedSpect.Shared;

namespace RedSpect.Core
{
    public class Probe
    {

        protected static ServiceHost ServiceHost { get; set; }

        public static void Start()
        {
            ServiceHost = new ServiceHost(typeof(InspectorService), new Uri[] { new Uri("net.pipe://localhost") });
            ServiceHost.AddServiceEndpoint(typeof(IInspectorService), new NetNamedPipeBinding(), "InspectorService");
            ServiceHost.Open();

        }
        
        public static void Stop()
        {
            if (ServiceHost != null)
            {
                ServiceHost.Close();
            }
        }

    }
}
