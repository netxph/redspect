using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Interfaces
{
    public interface IProbeConnection
    {

        string Name { get; }
        ICommandRunner Create(string[] arguments);

    }
}
