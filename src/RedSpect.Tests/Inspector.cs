using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }

}
