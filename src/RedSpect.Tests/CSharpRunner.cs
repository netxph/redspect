using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Tests
{
    public class CSharpRunner : IRunner
    {

        Dictionary<string, Func<string>> _csharpCommands;

        public CSharpRunner()
        {
            _csharpCommands = new Dictionary<string, Func<string>>();
            _csharpCommands.Add("CSGetStaticMessage", GetStaticMessage);
            _csharpCommands.Add("CSGetStaticAlertMessage", GetStaticAlertMessage);
            _csharpCommands.Add("CSExceptionThrower", ExceptionThrower);
        }

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
                return _csharpCommands[context.Command]();
            }

            throw new InvalidOperationException("Command not found.");
        }

        public bool CanExecute(ExecutionContext context)
        {
            return _csharpCommands.ContainsKey(context.Command);
        }

        public static string GetStaticMessage()
        {
            return Constants.MESSAGE;
        }

        public static string GetStaticAlertMessage()
        {
            return Constants.ALERT_MSG;
        }

        public static string ExceptionThrower()
        {
            throw new NotImplementedException("No implementation.");
        }
    }
}
