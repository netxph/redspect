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
        private static IInspectorService _inspectorService = null;
        private static bool _isConnected = false;

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

        public static void Execute(string commandName, object parameter)
        {
            if (!string.IsNullOrEmpty(commandName))
            {
                if (_commands.ContainsKey(commandName))
                {
                    _commands[commandName].Execute(parameter);
                }
                else if (IsConnected && InspectorService.ContainsCommand(commandName))
                {
                    InspectorService.Execute(commandName, parameter);
                }
                else
                {
                    System.Console.WriteLine("Command not found.");
                }
            }
        }

        public static void Connect()
        {
            if (!IsConnected)
            {
                System.Console.WriteLine(string.Format("Connected -> {0}", InspectorService.HostDetails()));
                _isConnected = true;
            }
            else
            {
                System.Console.WriteLine("Already connected.");
            }
        }

        public static void Disconnect()
        {
            _isConnected = false;
            System.Console.WriteLine("Disconnected.");
        }

        public static void Exit()
        {
            if (Exiting != null)
            {
                Exiting(null, new EventArgs());
            }
        }

        protected static IInspectorService InspectorService
        {
            get
            {
                if (_inspectorService == null)
                {
                    _inspectorService = Activator.GetObject(typeof(IInspectorService), "ipc://Diagnostics/InspectorService") as IInspectorService;
                }

                return _inspectorService;
            }
        }

        public static bool IsConnected
        { 
            get
            {
                return _isConnected;
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
