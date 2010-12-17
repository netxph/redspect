using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.ComponentModel
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandAttribute : Attribute
    {

        public CommandAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}
