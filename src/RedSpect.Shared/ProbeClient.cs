using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace RedSpect.Shared
{
    public class ProbeClient
    {

        public static IInspectorService Create()
        {
            IInspectorService service = null;

            ChannelFactory<IInspectorService> pipeFactory = new ChannelFactory<IInspectorService>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/InspectorService"));
            service = pipeFactory.CreateChannel();

            return service;
        }

    }
}
