using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Interfaces
{
    public interface IInspectorCommand
    {

        string Name { get; }
        void Test();

    }
}
