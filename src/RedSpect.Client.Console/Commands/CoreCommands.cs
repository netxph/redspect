using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared.Command;

namespace RedSpect.Client.Console.Commands
{
    public class CoreCommands : CommandGroupBase
    {

        const string COMMAND_SET_NAME = "Core";

        public override string Name
        {
            get { return COMMAND_SET_NAME; }
        }

        [Command("Exit")]
        public ActionResult Exit(object args)
        {
            CommandManager.Exit();
            return null;
        }

        [Command("Connect")]
        public ActionResult Connect(object args)
        {
            return CommandManager.Connect();
        }

        [Command("Disconnect")]
        public ActionResult Disconnect(object args)
        {
            return CommandManager.Disconnect();
        }

        [Command("About")]
        public ActionResult About(object args)
        {
            ResultBuilder builder = new ResultBuilder();

            builder.WriteLine("RedSpect 1.0 Copyright (c) Navitaire 2010");
            builder.WriteLine("ALPHA version! Use at your own risk.");

            return builder.CreateResult(null);
        }

    }
}
