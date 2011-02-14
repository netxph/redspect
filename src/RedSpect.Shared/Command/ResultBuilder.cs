using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace RedSpect.Shared.Contracts
{
    public class ResultBuilder
    {

        private List<TraceOutput> _traceOutput = null;

        public List<TraceOutput> TraceOutput
        {
            get
            {
                if (_traceOutput == null)
                {
                    _traceOutput = new List<TraceOutput>();
                }

                return _traceOutput;
            }
        }

        public void WriteLine(string output)
        {
            WriteLine(output, TraceEventType.Verbose);
        }

        public void WriteLine(string output, TraceEventType traceEventType)
        {
            TraceOutput.Add(new TraceOutput(output, traceEventType));
        }

        public void WriteLine()
        {
            WriteLine(string.Empty);
        }

        public ActionResult CreateResult(object value)
        {
            return new ActionResult(TraceOutput, value);
        }

        public ActionResult CreateResult()
        {
            return CreateResult(null);
        }

    }
}
