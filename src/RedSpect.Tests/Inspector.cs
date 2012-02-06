using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Scripting.CSharp;
using System.Reflection;
using IronRuby;

namespace RedSpect.Tests
{
    public class Inspector
    {

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

            switch (context.Type)
            {
                case "cs":
                    return new CSharpRunner().Execute(context);
                case "rs":
                    return new RoslynRunner().Execute(context);
                case "rb":
                    return new RubyRunner().Execute(context);
                default:
                    throw new NotSupportedException("Command type is not supported.");
            }

        }

    }

}
