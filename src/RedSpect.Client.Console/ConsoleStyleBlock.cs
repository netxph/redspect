using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RedSpect.Client.Console
{
    public class ConsoleStyle
    {
        public static void WriteLine(string value)
        {
            ConsoleColor defaultColor = System.Console.ForegroundColor;
            
            writeColor(value);

            System.Console.ForegroundColor = defaultColor;
        }

        private static void writeColor(string value)
        {
            Regex regex = new Regex("\\A[[A-Za-z]+]");
            Match match = regex.Match(value);

            if (!string.IsNullOrEmpty(match.Value))
            {
                value = regex.Replace(value, "");

                string colorString = match.Value.Replace("[", "").Replace("]", "");
                System.Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorString, true);
            }

            System.Console.WriteLine(value);
        }
    }

}
