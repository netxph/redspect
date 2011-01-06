using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Client.Console.Commands;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared.Command;

namespace RedSpect.Client.Console
{
    public class CommandManager
    {

        private static Dictionary<string, ICommandGroup> _commandGroups = null;
        private static Dictionary<string, ICommand> _commands = null;
        private static IInspectProvider _inspectorService = null;
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

        public static ActionResult Execute(string commandName, object parameter)
        {
            if (!string.IsNullOrEmpty(commandName))
            {
                if (_commands.ContainsKey(commandName))
                {
                    return _commands[commandName].Execute(parameter);
                }
                else if (IsConnected && InspectProvider.ContainsCommand(commandName))
                {
                    return InspectProvider.Execute(commandName, parameter);
                }
                else
                {
                    return new ErrorResult("Command not found.");
                }
            }

            return null;
        }

        public static ActionResult Connect()
        {
            ResultBuilder builder = new ResultBuilder();

            if (!IsConnected)
            {
                builder.WriteLine(string.Format("Connected -> {0}", InspectProvider.HostDetails()));
                _isConnected = true;
            }
            else
            {
                builder.WriteLine("Already connected.");
            }

            return builder.CreateResult(null);
        }

        public static ActionResult Disconnect()
        {
            ResultBuilder builder = new ResultBuilder();
            _isConnected = false;
            builder.WriteLine("Disconnected.");

            return builder.CreateResult(null);
        }

        public static void Exit()
        {
            if (Exiting != null)
            {
                Exiting(null, new EventArgs());
            }
        }

        protected static IInspectProvider InspectProvider
        {
            get
            {
                if (_inspectorService == null)
                {
                    _inspectorService = Activator.GetObject(typeof(IInspectProvider), "ipc://Diagnostics/InspectorService") as IInspectProvider;
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
