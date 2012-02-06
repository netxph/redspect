using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RedSpect.Tests
{
    public class RoslynRunnerTests
    {

        public class SupportedType
        {
            [Fact]
            public void EnsureSupportedTypeTest()
            {
                Assert.Equal<string>("rs", new RoslynRunner().SupportedType);
            }
        }

        public class CanExecute
        {
            [Fact]
            public void EnsureCanExecuteIsAlwaysTrue()
            {
                var runner = new RoslynRunner();

                Assert.True(runner.CanExecute(null));
            }
        }

        public class Execute
        {

            [Fact]
            public void ExecutesBasicCommandTest()
            {
                string expected = "Hello World";

                var runner = new RoslynRunner();
                ExecutionContext context = new ExecutionContext() { Command = "RedSpect.Tests.Constants.MESSAGE", Type = "rs" };
                context.ReferenceAssemblies = new string[] { this.GetType().Assembly.Location };

                string actual = runner.Execute(context).ToString();

                Assert.Equal(expected, actual);
            }

        }

    }
}
