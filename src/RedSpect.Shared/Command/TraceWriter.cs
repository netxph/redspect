using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace RedSpect.Shared.Command
{
    public class TraceWriter
    {

        public static void WriteAll(ActionResult output, TraceListener listener)
        {
            Trace.Listeners.Clear();
            Trace.Listeners.Add(new ExtendedConsoleTraceListener());

            foreach (var lineOutput in output.Output)
            {
                switch (lineOutput.TraceEventType)
                { 
                    case TraceEventType.Error:
                        Trace.TraceError(lineOutput.Message);
                        break;
                    case TraceEventType.Warning:
                        Trace.TraceWarning(lineOutput.Message);
                        break;
                    default:
                        Trace.WriteLine(lineOutput.Message);
                        break;
                }
            }

            if (output.Value != null)
            {
                Trace.TraceInformation(string.Format("=> {0}", output.Value.ToString()));
            }
        }

    }
}
