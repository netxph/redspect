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

                ExecutionContext context = new ExecutionContext() { Command = "CSGetStaticMessage", Type = "cs" };

                string actual = RedSpect.Tests.Inspector.Execute<string>(context);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void CSharpRetrieveStaticAlertMessageTest()
            {
                string expected = "ALERT!! ALERT!!";

                ExecutionContext context = new ExecutionContext() { Command = "CSGetStaticAlertMessage", Type = "cs" };

                string actual = RedSpect.Tests.Inspector.Execute<string>(context);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RoslynRetrieveStaticMessageTest()
            {
                string expected = "Hello World";

                ExecutionContext context = new ExecutionContext() { Command = "RedSpect.Tests.Constants.MESSAGE", Type = "rs" };

                var actual = RedSpect.Tests.Inspector.Execute<string>(context);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RoslynRetrieveStaticAlertMessageTest()
            {
                string expected = "ALERT!! ALERT!!";

                ExecutionContext context = new ExecutionContext() { Command = "RedSpect.Tests.Constants.ALERT_MSG", Type = "rs" };

                var actual = RedSpect.Tests.Inspector.Execute<string>(context);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RubyRetrieveStaticMessageTest()
            {
                string expected = "Hello World";

                ExecutionContext context = new ExecutionContext() { Command = "RedSpect::Tests::Constants.MESSAGE", Type = "rb" };

                var actual = RedSpect.Tests.Inspector.Execute<string>(context);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RubyRetrieveStaticAlertMessageTest()
            {
                string expected = "ALERT!! ALERT!!";

                ExecutionContext context = new ExecutionContext() { Command = "RedSpect::Tests::Constants.ALERT_MSG", Type = "rb" };

                var actual = RedSpect.Tests.Inspector.Execute<string>(context);

                Assert.Equal<string>(expected, actual);
            }

            [Fact]
            public void RetrieveMessageEmptyCommandTest()
            {

                ExecutionContext context = new ExecutionContext() { Command = "", Type = "cs" };

                Assert.Throws(typeof(ArgumentNullException), () =>
                {
                    string actual = RedSpect.Tests.Inspector.Execute<string>(context);
                });
                
            }

            [Fact]
            public void RetrieveMessageEmptyCommandTypeTest()
            {
                ExecutionContext context = new ExecutionContext() { Command = "CSGetStaticMessage", Type = string.Empty };

                Assert.Throws(typeof(ArgumentNullException), () =>
                {
                    string actual = RedSpect.Tests.Inspector.Execute<string>(context);
                });
            }

            [Fact]
            public void OverloadTest()
            {

                string expected = "Hello World";

                string command = "CSGetStaticMessage";

                string actual = RedSpect.Tests.Inspector.Execute<string>(command);

                Assert.Equal<string>(expected, actual);

            }

            [Fact]
            public void CommandNotFoundTest()
            {
                string command = "NotAValidCommand";

                Assert.Throws(typeof(InvalidOperationException), () =>
                {
                    RedSpect.Tests.Inspector.Execute<string>(command);
                });
            }

            [Fact]
            public void CommandTypeNotFoundTest()
            {
                ExecutionContext context = new ExecutionContext() { Command = "CSGetStaticMessage", Type = "xx" };

                Assert.Throws(typeof(NotSupportedException), () => 
                {
                    RedSpect.Tests.Inspector.Execute(context);
                });

            }

            [Fact]
            public void CommandExecutionFailed()
            {
                string command = "CSExceptionThrower";

                var exception = Record.Exception(() =>
                {
                    RedSpect.Tests.Inspector.Execute<string>(command);
                });

                Assert.NotNull(exception);
                Assert.NotEqual(exception.GetType(), typeof(InvalidOperationException));
            }

        }

    }
}
