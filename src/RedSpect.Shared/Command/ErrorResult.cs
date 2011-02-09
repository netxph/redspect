using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace RedSpect.Shared.Command
{
    public class ErrorResult : ActionResult
    {
        public ErrorResult(string message)
        {
            Output = new List<TraceOutput>() { new TraceOutput(message, TraceEventType.Error) };
        }

    }
}
