using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Tests
{
    public interface IRunner
    {

        string SupportedType { get; }
        object Execute(ExecutionContext context);
        bool CanExecute(ExecutionContext context);

    }
}
