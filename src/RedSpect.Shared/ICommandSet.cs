using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared
{
    public interface ICommandSet
    {

        Dictionary<string, Func<string[], object>> GetCommands();

    }
}
