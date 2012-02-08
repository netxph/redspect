using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using RedSpect.Shared;

namespace RedSpect.Tests
{

    [Export(typeof(ICommandSet))]
    public class TestCommandSet : BaseCommandSet
    {

        [Command("CSGetStaticMessage")]
        public object GetStaticMessage(string[] args)
        {
            return Constants.MESSAGE;
        }

        [Command("CSGetStaticAlertMessage")]
        public object GetStaticAlertMessage(string[] args)
        {
            return Constants.ALERT_MSG;
        }

        [Command("CSExceptionThrower")]
        public object ExceptionThrower(string[] args)
        {
            throw new NotImplementedException("No implementation.");
        }

    }
}
