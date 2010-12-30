using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
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
        public void Exit(object args)
        {
            CommandManager.Exit();
        }

        [Command("About")]
        public void About(object args)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("RedSpect 1.0 Copyright (c) Navitaire 2010");
            builder.AppendLine("ALPHA version! Use at your own risk.");
            builder.AppendLine();

            System.Console.WriteLine(builder.ToString());
        }

    }
}
