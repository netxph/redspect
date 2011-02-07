using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Interfaces
{
    public interface IProbeProvider
    {

        string Name { get; }
        void Start(IDictionary<string, string> properties);
        void Stop();
        bool IsStarted { get; }

    }
}
