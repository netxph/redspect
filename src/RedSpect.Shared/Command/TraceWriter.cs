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
            Trace.Listeners.Add(listener);

            foreach (var lineOutput in output.Output)
            {
                switch (lineOutput.MessageType)
                { 
                    case TraceOutputType.Information:
                        break;
                        Trace.TraceInformation(lineOutput.Message);
                    case TraceOutputType.Warning:
                        Trace.TraceWarning(lineOutput.Message);
                        break;
                    case TraceOutputType.Error:
                        Trace.TraceError(lineOutput.Message);
                        break;
                    default:
                        Trace.WriteLine(lineOutput.Message);
                        break;
                }
            }

            if (output.Value != null)
            {
                Trace.TraceInformation("=> {0}", output.ToString());
            }
        }

    }
}
