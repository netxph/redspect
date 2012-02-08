using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared;

namespace RedSpect.Core
{
    public class InspectorService : IInspectorService
    {
        public string Execute(ExecutionContext context)
        {
            return Inspector.Execute<string>(context);
        }

    }
}
