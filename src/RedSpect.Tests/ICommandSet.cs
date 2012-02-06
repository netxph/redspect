using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Tests
{
    public interface ICommandSet
    {

        Dictionary<string, Func<string[], object>> GetCommands();

    }
}
