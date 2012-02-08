using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using RedSpect.Core.Runners;
using RedSpect.Shared;

namespace RedSpect.Tests
{
    public class RubyRunnerTests
    {

        public class SupportedType
        {
            [Fact]
            public void EnsureSupportedTypeTest()
            {
                Assert.Equal<string>("rb", new RubyRunner().SupportedType);
            }
        }

        public class CanExecute
        {
            [Fact]
            public void EnsureCanExecuteIsAlwaysTrue()
            {
                var runner = new RubyRunner();

                Assert.True(runner.CanExecute(null));
            }
        }

        public class Execute
        {

            [Fact]
            public void ExecutesBasicCommandTest()
            {
                string expected = "Hello World";

                var runner = new RubyRunner();
                ExecutionContext context = new ExecutionContext() { Command = "RedSpect::Tests::Constants.MESSAGE", Type = "rb" };
                context.ReferenceAssemblies = new string[] { this.GetType().Assembly.Location };

                string actual = runner.Execute(context).ToString();

                Assert.Equal(expected, actual);
            }

        }

    }
}
