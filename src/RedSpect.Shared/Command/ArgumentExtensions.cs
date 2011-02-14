using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Contracts
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

        public static string GetProperty(this IDictionary<string, string> properties, string key, string defaultValue)
        {
            if (properties.ContainsKey(key))
            {
                return properties[key];
            }

            return defaultValue;
        }

        public static string GetProperty(this IDictionary<string, string> properties, string key)
        {
            return GetProperty(properties, key, null);
        }

    }
}
