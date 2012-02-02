using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Scripting.CSharp;
using System.Reflection;

namespace RedSpect.Tests
{
    public class Inspector
    {

        static Dictionary<string, Func<string>> _commands;

        static Inspector()
        {
            _commands = new Dictionary<string, Func<string>>();
            _commands.Add("CSGetStaticMessage", GetStaticMessage);
            _commands.Add("CSGetStaticAlertMessage", GetStaticAlertMessage);
            _commands.Add("RSGetStaticMessage", RSGetStaticMessage);
            _commands.Add("RSGetStaticAlertMessage", RSGetStaticAlertMessage);
        }

        public static string Execute(string command)
        {
            return _commands[command]();
        }

        public static string GetStaticMessage()
        {
            return Constants.MESSAGE;
        }

        public static string GetStaticAlertMessage()
        {
            return Constants.ALERT_MSG;
        }

        public static string RSGetStaticAlertMessage()
        {
            var engine = new ScriptEngine(new[] { "System", Assembly.GetExecutingAssembly().Location });
            string actual = engine.Execute("using RedSpect.Tests; Constants.ALERT_MSG").ToString();

            return actual;
        }

        public static string RSGetStaticMessage()
        {
            var engine = new ScriptEngine(new[] { "System", Assembly.GetExecutingAssembly().Location });
            string actual = engine.Execute("using RedSpect.Tests; Constants.MESSAGE").ToString();

            return actual;
        }
    }

}
