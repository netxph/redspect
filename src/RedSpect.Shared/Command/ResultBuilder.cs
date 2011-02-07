using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Command
{
    public class ResultBuilder
    {

        private List<string> _consoleOutput = null;

        public List<string> ConsoleOutput 
        {
            get
            {
                if (_consoleOutput == null)
                {
                    _consoleOutput = new List<string>();
                }

                return _consoleOutput;
            }
        }

        

        public void WriteLine(string output)
        {
            ConsoleOutput.Add(output);
        }

        public void WriteLine(string output, ConsoleColor color)
        {
            ConsoleOutput.Add(string.Format("[{0}]{1}", color.ToString(), output));
        }

        public void WriteLine()
        {
            WriteLine(string.Empty);
        }

        public ActionResult CreateResult(object value)
        {
            return new ActionResult(ConsoleOutput, value);
        }

        public ActionResult CreateResult()
        {
            return CreateResult(null);
        }

    }
}
