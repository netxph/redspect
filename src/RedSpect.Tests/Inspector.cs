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

        static Dictionary<string, Func<string>> _csharpCommands;

        static Inspector()
        {
            _csharpCommands = new Dictionary<string, Func<string>>();
            _csharpCommands.Add("CSGetStaticMessage", GetStaticMessage);
            _csharpCommands.Add("CSGetStaticAlertMessage", GetStaticAlertMessage);
            _csharpCommands.Add("CSExceptionThrower", ExceptionThrower);
        }

        public static string Execute(string command)
        {
            return Execute(command, "cs");
        }

        public static string Execute(string command, string commandType)
        {
            //validation
            if (string.IsNullOrEmpty(command)) throw new ArgumentNullException("Command script is required.");
            if (string.IsNullOrEmpty(commandType)) throw new ArgumentNullException("Command type is required.");

            switch (commandType)
            {
                case "cs":
                    return RunCSharpScript(command);
                case "rs":
                    return RunRoslynScript(command);
                case "rb":
                    return RunRubyScript(command);
                default:
                    throw new NotSupportedException("Command type is not supported.");
            }

        }

        public static string RunCSharpScript(string command)
        {

            if (_csharpCommands.ContainsKey(command))
            {
                return _csharpCommands[command]();
            }

            throw new InvalidOperationException("Command not found.");
        }

        public static string RunRubyScript(string command)
        {
            string script = string.Format("require \"{0}\"\r\n{1}", Assembly.GetExecutingAssembly().Location.Replace('\\', '/'), command);

            var engine = Ruby.CreateEngine();
            string result = engine.Execute<string>(script);

            return result;
        }

        public static string RunRoslynScript(string command)
        {
            var engine = new ScriptEngine(new[] { "System", Assembly.GetExecutingAssembly().Location });
            string result = engine.Execute(command).ToString();

            return result;
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
