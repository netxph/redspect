using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared;
using RedSpect.Shared.Command;

namespace RedSpect.HostTest.Win
{
    public class WindowsTestCommand : CommandGroupBase, IInspectorCommandGroup
    {
        public override string Name
        {
            get { return "WindowsTest"; }
        }

        public override void Test()
        {
            Injection.WriteForm("Message from outer application.");
        }

        [Command("WriteValueOfX")]
        public ActionResult WriteValueOfX(object args)
        {
            ResultBuilder builder = new ResultBuilder();

            Injection.WriteForm(string.Format("The value of X is {0}", Injection.X));
            builder.WriteLine("Sent to target client.");

            return builder.CreateResult(null);
        }

        [Command("GetValueOfX")]
        public ActionResult GetValueOfX(object args)
        {
            ResultBuilder builder = new ResultBuilder();
            return builder.CreateResult(Injection.X);
        }

    }
}
