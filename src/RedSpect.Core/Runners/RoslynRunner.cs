using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Scripting.CSharp;
using System.Reflection;
using System.ComponentModel.Composition;

namespace RedSpect.Tests
{
    [Export(typeof(IRunner))]
    public class RoslynRunner : IRunner
    {

        const string SUPPORTED_TYPE = "rs";

        public string SupportedType
        {
            get { return SUPPORTED_TYPE; }
        }

        public object Execute(ExecutionContext context)
        {
            if (CanExecute(context))
            {
                List<string> namespaces = new List<string>() { "System" };

                foreach (var reference in context.ReferenceAssemblies)
                {
                    namespaces.Add(reference);
                }

                var engine = new ScriptEngine(namespaces);
                
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
