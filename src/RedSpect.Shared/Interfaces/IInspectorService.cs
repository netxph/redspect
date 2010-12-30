using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Shared.Interfaces
{
    public interface IInspectorService
    {

        string HostDetails();
        void TestCommandSet(string name);

    }
}
