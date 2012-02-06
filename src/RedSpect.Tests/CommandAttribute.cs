using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Tests
{
    public class CommandAttribute : Attribute
    {

        public CommandAttribute()
        {

        }

        public CommandAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Func<string[], object> ActionCommand { get; set; }

    }
}
