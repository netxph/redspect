using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Interfaces
{
    public interface ICommandGroup
    {

        string Name { get; }
        Dictionary<string, ICommand> Commands { get; }

        void Test();

    }
}
