using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedSpect.Shared.Command
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
            : this(message, TraceOutputType.Default)
        {

        }

        public TraceOutput(string message, TraceOutputType messageType)
        {
            Message = message;
            MessageType = messageType;
        }

        #endregion

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public TraceOutputType MessageType { get; set; }

    }

    [DataContract]
    public enum TraceOutputType
    { 
        [DataMember]
        Default,

        [DataMember]
        Information,

        [DataMember]
        Warning,

        [DataMember]
        Error
    }
}
