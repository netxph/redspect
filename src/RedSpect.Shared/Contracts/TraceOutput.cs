using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace RedSpect.Shared.Contracts
{
    [DataContract]
    [Serializable]
    public class TraceOutput
    {
        #region Constructors

        public TraceOutput()
        {
        }

        public TraceOutput(string message)
            : this(message, TraceEventType.Verbose)
        {

        }

        public TraceOutput(string message, TraceEventType traceEventType)
        {
            Message = message;
            TraceEventType = traceEventType;
        }

        #endregion

        #region Properties

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public TraceEventType TraceEventType { get; set; }

        #endregion

    }

}
