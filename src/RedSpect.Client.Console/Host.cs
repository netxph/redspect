using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Client.Console.Commands;
using RedSpect.Shared.Command;

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

            while(!_exiting)
            {
                try
                {
                    System.Console.Write(CommandManager.Prompt);
                    command = new Arguments(System.Console.ReadLine());

                    ActionResult result = CommandManager.Execute(command);

                    if (result != null)
                    {
                        if (result.Output != null)
                        {
                            foreach (var outputLine in result.Output)
                            {
                                ConsoleStyle.WriteLine(outputLine);
                            }
                        }

                        if (result.Value != null)
                        {
                            System.Console.WriteLine(string.Format("=> {0}", result.Value));
                        }
                        
                        System.Console.WriteLine();
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
