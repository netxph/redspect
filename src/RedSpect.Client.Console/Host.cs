using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Client.Console.Commands;
using RedSpect.Shared.Contracts;
using System.Diagnostics;

namespace RedSpect.Client.Console
{
    public class Host
    {

        private static bool _exiting = false;

        public static void Run()
        {
            string command = null;
            CommandManager.Exiting += new EventHandler(CommandManager_Exiting);
            CommandManager.RegisterCommandGroup(new CoreCommands());

            while(!_exiting)
            {
                try
                {
                    System.Console.Write(CommandManager.Prompt);
                    command = System.Console.ReadLine();

                    if (!string.IsNullOrEmpty(command.Trim()))
                    {
                        ActionResult result = CommandManager.Execute(new Arguments(command));

                        if (result != null)
                        {
                            TraceWriter.WriteAll(result, new ConsoleTraceListener());

                            System.Console.WriteLine();
                        }
                    }

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
