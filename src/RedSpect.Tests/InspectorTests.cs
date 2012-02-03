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
                string commandType = "cs";

                string actual = RedSpect.Tests.Inspector.Execute(command, commandType);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void CSharpRetrieveStaticAlertMessageTest()
            {
                string expected = "ALERT!! ALERT!!";

                string command = "CSGetStaticAlertMessage";
                string commandType = "cs";

                string actual = RedSpect.Tests.Inspector.Execute(command, commandType);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RoslynRetrieveStaticMessageTest()
            {
                string expected = "Hello World";

                string command = "RedSpect.Tests.Constants.MESSAGE";
                string commandType = "rs";

                var actual = RedSpect.Tests.Inspector.Execute(command, commandType);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RoslynRetrieveStaticAlertMessageTest()
            {
                string expected = "ALERT!! ALERT!!";

                string command = "RedSpect.Tests.Constants.ALERT_MSG";
                string commandType = "rs";

                var actual = RedSpect.Tests.Inspector.Execute(command, commandType);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RubyRetrieveStaticMessageTest()
            {
                string expected = "Hello World";

                string command = "RedSpect::Tests::Constants.MESSAGE";
                string commandType = "rb";

                var actual = RedSpect.Tests.Inspector.Execute(command, commandType);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RubyRetrieveStaticAlertMessageTest()
            {
                string expected = "ALERT!! ALERT!!";

                string command = "RedSpect::Tests::Constants.ALERT_MSG";
                string commandType = "rb";

                var actual = RedSpect.Tests.Inspector.Execute(command, commandType);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RetrieveMessageEmptyCommandTest()
            {
                string command = "";
                string commandType = "cs";

                Assert.Throws(typeof(ArgumentNullException), () =>
                {
                    string actual = RedSpect.Tests.Inspector.Execute(command, commandType);
                });
                
            }

            [Fact]
            public void RetrieveMessageEmptyCommandTypeTest()
            {
                string command = "CSGetStaticMessage";
                string commandType = string.Empty;

                Assert.Throws(typeof(ArgumentNullException), () =>
                {
                    string actual = RedSpect.Tests.Inspector.Execute(command, commandType);
                });
            }

            [Fact]
            public void OverloadTest()
            {

                string expected = "Hello World";

                string command = "CSGetStaticMessage";

                string actual = RedSpect.Tests.Inspector.Execute(command);

                Assert.Equal<string>(expected, actual);

            }

            [Fact]
            public void CommandNotFoundTest()
            {
                string command = "NotAValidCommand";

                Assert.Throws(typeof(InvalidOperationException), () =>
                {
                    RedSpect.Tests.Inspector.Execute(command);
                });
            }

            [Fact]
            public void CommandTypeNotFoundTest()
            {
                string command = "CSGetStaticMessage";
                string commandType = "xx";

                Assert.Throws(typeof(NotSupportedException), () => 
                {
                    RedSpect.Tests.Inspector.Execute(command, commandType);
                });

            }

            [Fact]
            public void CommandExecutionFailed()
            {
                string command = "CSExceptionThrower";

                var exception = Record.Exception(() =>
                {
                    RedSpect.Tests.Inspector.Execute(command);
                });

                Assert.NotNull(exception);
                Assert.NotEqual(exception.GetType(), typeof(InvalidOperationException));
            }

        }

    }
}
