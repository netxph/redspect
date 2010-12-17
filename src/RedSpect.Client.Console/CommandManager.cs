using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.ComponentModel;
using RedSpect.Client.Console.Commands;

namespace RedSpect.Client.Console
{
    public class CommandManager
    {

        public static ICommandSet CurrentCommandSet { get; set; }
        public static Dictionary<string, ICommandSet> CommandSets { get; set; }

        static CommandManager()
        {
            ICommandSet basic = new Basic();
            ICommandSet test = new Test();

            CommandSets = new Dictionary<string, ICommandSet>();
            CommandSets.Add(basic.Name, basic);
            CommandSets.Add(test.Name, test);

            CurrentCommandSet = test;
        }

        public static void Set(string name)
        {
            CurrentCommandSet = CommandSets[name];
        }

        public static void Execute(string commandName, object parameter)
        {
            if (!string.IsNullOrEmpty(commandName))
            {
                CurrentCommandSet.Commands[commandName].Execute(parameter);
            }
        }

        public static string Prompt 
        {
            get
            {
                return string.Format("[{0}] > ", CurrentCommandSet.Name);
            }
        }
    }
}
