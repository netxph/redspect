using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared
{
    [AttributeUsage(AttributeTargets.Method)]
    public class InspectorCommandAttribute : Attribute
    {

        public InspectorCommandAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        
    }
}
