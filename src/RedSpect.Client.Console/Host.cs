using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Client.Console
{
    public class Host
    {

        public static void Run()
        {
            Arguments command = null;

            do
            {
                System.Console.Write(CommandManager.Prompt);
                command = new Arguments(System.Console.ReadLine());

                CommandManager.Execute(command.CommandName, command.Parameters);

            } while (!command.IsExit);
        }

    }
}
