using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Scripting.CSharp;
using System.Reflection;

namespace RedSpect.Tests
{
    public class RoslynRunner : IRunner
    {
        public string SupportedType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object Execute(ExecutionContext context)
        {
            if (CanExecute(context))
            {
                var engine = new ScriptEngine(new[] { "System", Assembly.GetExecutingAssembly().Location });
                string result = engine.Execute(context.Command).ToString();

                return result;
            }

            throw new InvalidOperationException("Error executing command.");
        }

        public bool CanExecute(ExecutionContext context)
        {
            //since this is an open script, it always returns true
            return true;
        }
    }
}
