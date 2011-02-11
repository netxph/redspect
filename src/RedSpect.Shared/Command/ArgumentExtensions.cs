using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Command
{
    public static class ArgumentExtensions
    {

        public static string GetArgument(this string[] arguments, int index, string defaultValue)
        {
            if (arguments.Length > index && index >= 0)
            {
                return arguments[index];
            }

            return defaultValue;
        }

        public static string GetArgument(this string[] arguments, int index)
        {
            return GetArgument(arguments, index, string.Empty);
        }

    }
}
