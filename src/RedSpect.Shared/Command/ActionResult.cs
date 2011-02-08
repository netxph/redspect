using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Command
{
    [Serializable]
    public class ActionResult
    {

        #region Constructors

        public ActionResult()
        {

        }

        public ActionResult(IEnumerable<TraceOutput> output, object value)
        {
            Output = output;
            Value = value;
        }

        #endregion

        #region Properties

        public IEnumerable<TraceOutput> Output { get; set; }

        public object Value { get; set; }

        #endregion

    }
}
