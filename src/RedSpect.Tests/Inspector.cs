using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Scripting.CSharp;
using System.Reflection;
using IronRuby;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace RedSpect.Tests
{
    public class Inspector
    {

        static Inspector()
        {
            RunnerContext runnerContext = new RunnerContext();
            Runners = new Dictionary<string, IRunner>();

            foreach (var runner in runnerContext.Runners)
            {
                Runners.Add(runner.SupportedType, runner);
            }
        }

        public static Dictionary<string, IRunner> Runners { get; set; }

        public static T Execute<T>(string command)
        {
            return (T)Execute(new ExecutionContext() { Command = command, Type = "cs" });
        }

        public static T Execute<T>(ExecutionContext context)
        {
            return (T)Execute(context);
        }

        public static object Execute(ExecutionContext context)
        {
            //validation
            if (string.IsNullOrEmpty(context.Command)) throw new ArgumentNullException("Command is required.");
            if (string.IsNullOrEmpty(context.Type)) throw new ArgumentNullException("Command type is required.");

            if (Runners.ContainsKey(context.Type))
            {
                return Runners[context.Type].Execute(context);
            }
            else
            {
                throw new NotSupportedException("Command type is not supported.");
            }

        }

    }

}
