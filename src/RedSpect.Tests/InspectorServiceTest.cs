using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using RedSpect.Shared;
using RedSpect.Core;

namespace RedSpect.Tests
{
    public class InspectorServiceTest
    {

        public class Execute
        {
            [Fact]
            public void BasicCommandTest()
            {
                string expected = "Hello World";

                ExecutionContext context = new ExecutionContext() { Command = "CSGetStaticMessage", Type = "cs" };

                string actual = null;

                WrapProbe((proxy) =>
                {
                    actual = proxy.Execute(context);    
                });

                Assert.Equal<string>(expected, actual);
                
            }

            public void WrapProbe(Action<IInspectorService> action)
            {
                Probe.Start();

                action(ProbeClient.Create());

                Probe.Stop();
            }

            
            
        }

    }
}
