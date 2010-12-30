using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Client.Console.Commands;
using RedSpect.Shared.Interfaces;
using System.Windows.Input;

namespace RedSpect.Client.Console
{
    public class CommandManager
    {

        private static Dictionary<string, ICommandGroup> _commandGroups = null;
        private static Dictionary<string, ICommand> _commands = null;

        public static event EventHandler Exiting;

        static CommandManager()
        {

            _commandGroups = new Dictionary<string, ICommandGroup>();
            _commands = new Dictionary<string, ICommand>();

        }

        public static void RegisterCommandGroup(ICommandGroup commandGroup)
        {
            _commandGroups.Add(commandGroup.Name, commandGroup);

            foreach (string key in commandGroup.Commands.Keys)
            {
                _commands.Add(key, commandGroup.Commands[key]);
            }
        }

        public static void Set(string name)
        {

        }

        public static void Execute(string commandName, object parameter)
        {
            if (!string.IsNullOrEmpty(commandName))
            {
                _commands[commandName].Execute(parameter);
            }
        }

        public static void Exit()
        {
            if (Exiting != null)
            {
                Exiting(null, new EventArgs());
            }
        }

        public static string Prompt 
        {
            get
            {
                return string.Format("[{0}] > ", DateTime.Now.ToString("HH:mm:ss"));
            }
        }
    }
}
