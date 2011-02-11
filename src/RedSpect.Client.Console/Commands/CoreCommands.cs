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
        const string DEFAULT_CONNECTION = "IPC";

        public override string Name
        {
            get { return COMMAND_SET_NAME; }
        }

        [Command("Exit", "Exit redspect", "Exit")]
        public ActionResult Exit(object args)
        {
            CommandManager.Exit();
            return null;
        }

        [Command("Connect", "Attach to host", "Connect [ipc|remoting|injection]")]
        public ActionResult Connect(object args)
        {
            var arguments = new List<string>((string[])args);

            //[1] - connection type
            string connectionId = DEFAULT_CONNECTION;

            if (arguments.Count > 0)
            {
                connectionId = arguments[0];

                //strip arguments
                arguments.RemoveAt(0);
            }

            return CommandManager.Connect(connectionId, arguments.ToArray());
        }

        [Command("Disconnect", "Detach from host", "Disconnect")]
        public ActionResult Disconnect(object args)
        {
            return CommandManager.Disconnect();
        }

        [Command("Switch", "Switch command provider.", "Switch [rb|cs]")]
        public ActionResult Switch(object args)
        {
            var arguments = (string[])args;

            if (arguments.Length == 0 || string.IsNullOrEmpty(arguments[0]))
            {
                return new ErrorResult("Switch parameter is required. (cs or rb)");
            }

            CommandManager.State = (CommandState)Enum.Parse(typeof(CommandState), arguments[0], true);

            return null;
        }

        [Command("About", "Displays application details", "About")]
        public ActionResult About(object args)
        {
            ResultBuilder builder = new ResultBuilder();

            builder.WriteLine("RedSpect 1.0 Copyright (c) Navitaire 2010");
            builder.WriteLine("Marc Vitalis (c) 2011");

            return builder.CreateResult(null);
        }

        [Command("Help", "Shows information for a certain command", "Help [commandName]")]
        public ActionResult Help(object args)
        {
            var arguments = (string[])args;

            if (arguments.Length == 0 || string.IsNullOrEmpty(arguments[0]))
            {
                return CommandManager.GetCommand();
            }
            else
            {
                return CommandManager.GetCommand(arguments[0]);
            }
        }

    }
}
