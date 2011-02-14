using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Contracts
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {

        public CommandAttribute(string name)
            : this(name, string.Empty, string.Empty)
        {
            
        }

        public CommandAttribute(string name, string help)
            : this(name, help, string.Empty)
        {

        }

        public CommandAttribute(string name, string help, string usage)
        {
            Name = name;
            Help = help;
            Usage = usage;
        }

        public string Name { get; set; }

        public string Help { get; set; }

        public string Usage { get; set; }

    }
}
