using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Tests
{
    public class ExecutionContext
    {
        public string Command { get; set; }

        public string Type { get; set; }

        public string[] Arguments { get; set; }

        public string[] ReferenceAssemblies { get; set; }
    }
}
