using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Roslyn.Scripting.CSharp;

namespace RedSpect.Tests
{
    public class InspectorTests
    {

        public class Inspector
        {

            [Fact]
            public void CSharpRetrieveStaticMessageTest()
            {
                string expected = "Hello World";

                string command = "CSGetStaticMessage";

                string actual = RedSpect.Tests.Inspector.Execute(command);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void CSharpRetrieveStaticAlertMessageTest()
            {
                string expected = "ALERT!! ALERT!!";

                string command = "CSGetStaticAlertMessage";

                string actual = RedSpect.Tests.Inspector.Execute(command);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RoslynRetrieveStaticMessageTest()
            {
                string expected = "Hello World";

                string command = "RSGetStaticMessage";

                var actual = RedSpect.Tests.Inspector.Execute(command);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RoslynRetrieveStaticAlertMessageTest()
            {
                string expected = "ALERT!! ALERT!!";

                string command = "RSGetStaticAlertMessage";

                var actual = RedSpect.Tests.Inspector.Execute(command);

                Assert.Equal<string>(expected, actual);
            }

        }

    }
}
