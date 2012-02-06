using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronRuby;
using System.Reflection;
using System.ComponentModel.Composition;

namespace RedSpect.Tests
{
    [Export(typeof(IRunner))]
    public class RubyRunner : IRunner
    {
        const string SUPPORTED_TYPE = "rb";

        public string SupportedType
        {
            get { return SUPPORTED_TYPE; }
        }

        public object Execute(ExecutionContext context)
        {
            if (CanExecute(context))
            {
                //references
                StringBuilder builder = new StringBuilder();
                foreach (var reference in context.ReferenceAssemblies)
                {
                    builder.AppendFormat("require \"{0}\"\r\n", reference.Replace('\\', '/'));
                }

                builder.AppendLine(context.Command);

                string script = builder.ToString();

                var engine = Ruby.CreateEngine();
                string result = engine.Execute<string>(script);

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
