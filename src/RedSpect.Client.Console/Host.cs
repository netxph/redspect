using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Client.Console.Commands;

namespace RedSpect.Client.Console
{
    public class Host
    {

        private static bool _exiting = false;

        public static void Run()
        {
            Arguments command = null;
            CommandManager.Exiting += new EventHandler(CommandManager_Exiting);
            CommandManager.RegisterCommandGroup(new CoreCommands());
            CommandManager.RegisterCommandGroup(new TestCommands());

            while(!_exiting)
            {
                try
                {
                    System.Console.Write(CommandManager.Prompt);
                    command = new Arguments(System.Console.ReadLine());

                    CommandManager.Execute(command.CommandName, command.Parameters);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(string.Format("ERROR: {0}", ex.Message));
                }
            } 
        }

        protected static void CommandManager_Exiting(object sender, EventArgs e)
        {
            _exiting = true;
        }

    }
}
