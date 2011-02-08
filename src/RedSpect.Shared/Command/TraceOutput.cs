using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Command
{
    public class TraceOutput
    {
        #region Constructors

        public TraceOutput()
        {
        }

        public TraceOutput(string message)
            : this(message, TraceOutputType.Default)
        {

        }

        public TraceOutput(string message, TraceOutputType messageType)
        {
            Message = message;
            MessageType = messageType;
        }

        #endregion

        public string Message { get; set; }
        public TraceOutputType MessageType { get; set; }

    }

    public enum TraceOutputType
    { 
        Default,
        Information,
        Warning,
        Error
    }
}
