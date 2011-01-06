using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Command
{
    [Serializable]
    public class ActionResult
    {

        public ActionResult()
        {

        }

        public ActionResult(List<string> output, object value)
        {
            Output = output;
            Value = value;
        }

        public List<string> Output { get; set; }

        public object Value { get; set; }

    }
}
