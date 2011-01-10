using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Command
{
    [Serializable]
    public class ErrorResult : ActionResult
    {

        public ErrorResult(string message)
        {
            Output = new List<string>() { message };
        }

    }
}
