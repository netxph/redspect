using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RedSpect.Tests
{
    public class CSharpRunnerTests
    {

        public class SupportedType
        {
            [Fact]
            public void EnsureSupportedTypeTest()
            {
                Assert.Equal<string>("cs", new CSharpRunner().SupportedType);
            }
        }

        public class CanExecute
        {
            [Fact]
            public void EnsureTestCommandsAreCompleteTest()
            { 
                var runner = new CSharpRunner();

                Assert.True(runner.CanExecute(new ExecutionContext() { Command = "CSGetStaticMessage", Type = "cs" }));
                Assert.True(runner.CanExecute(new ExecutionContext() { Command = "CSGetStaticAlertMessage", Type = "cs" }));
                Assert.True(runner.CanExecute(new ExecutionContext() { Command = "CSExceptionThrower", Type = "cs" }));
            }

            [Fact]
            public void EnsureNonExistentCommandsReturnsFalseTest()
            { 
                var runner = new CSharpRunner();

                Assert.False(runner.CanExecute(new ExecutionContext() { Command = "NonExistent", Type = "cs" }));
            }
        }

        public class Execute
        {

            [Fact]
            public void ExecutesBasicCommandTest()
            {
                string expected = "Hello World";
                
                var runner = new CSharpRunner();
                ExecutionContext context = new ExecutionContext() { Command = "CSGetStaticMessage", Type = "cs" };

                string actual = runner.Execute(context).ToString();

                Assert.Equal(expected, actual);
            }

        }

    }
}
