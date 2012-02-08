using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared;
using System.ServiceModel;

namespace RedSpect.Shared
{

    [ServiceContract]
    public interface IInspectorService
    {

        [OperationContract]
        string Execute(ExecutionContext context);

    }
}
