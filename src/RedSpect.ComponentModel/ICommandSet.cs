using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace RedSpect.ComponentModel
{
    public interface ICommandSet
    {

        string Name { get; }
        Dictionary<string, ICommand> Commands { get; }

    }
}
