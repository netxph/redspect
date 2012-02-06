using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IronRuby;
using System.Reflection;

namespace RedSpect.Tests
{
    public class RubyRunner : IRunner
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
                string script = string.Format("require \"{0}\"\r\n{1}", Assembly.GetExecutingAssembly().Location.Replace('\\', '/'), context.Command);

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
