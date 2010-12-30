using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Client.Console.Commands;
using RedSpect.Shared.Interfaces;

namespace RedSpect.Client.Console
{
    public class CommandManager
    {

        public static ICommandGroup CurrentCommandGroup { get; set; }
        public static Dictionary<string, ICommandGroup> CommandGroups { get; set; }

        static CommandManager()
        {
            ICommandGroup basic = new Basic();
            ICommandGroup test = new ConsoleTest();

            CommandGroups = new Dictionary<string, ICommandGroup>();
            CommandGroups.Add(basic.Name, basic);
            CommandGroups.Add(test.Name, test);

            CurrentCommandGroup = test;
        }

        public static void Set(string name)
        {
            CurrentCommandGroup = CommandGroups[name];
        }

        public static void Execute(string commandName, object parameter)
        {
            if (!string.IsNullOrEmpty(commandName))
            {
                CurrentCommandGroup.Commands[commandName].Execute(parameter);
            }
        }

        public static string Prompt 
        {
            get
            {
                return string.Format("[{0}] > ", CurrentCommandGroup.Name);
            }
        }
    }
}
