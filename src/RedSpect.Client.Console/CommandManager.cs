using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Client.Console.Commands;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared.Command;

namespace RedSpect.Client.Console
{
    public enum CommandState
    { 
        CS,
        RB
    }

    public class CommandManager
    {

        const string BLOCK_COMMAND = ">>";

        private static Dictionary<string, ICommandGroup> _commandGroups = null;
        private static Dictionary<string, ICommand> _commands = null;
        private static IInspectProvider _inspectorProvider = null;
        private static bool _isConnected = false;

        public static event EventHandler Exiting;

        public static CommandState State { get; set; }

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

        public static ActionResult Execute(Arguments arguments)
        {
            if (arguments.Command.StartsWith("!"))
            {
                arguments = new Arguments(arguments.Command.Remove(0, 1));
                return Execute(arguments.CommandName, arguments.Parameters);
            }

            if (State == CommandState.CS)
            {
                return Execute(arguments.CommandName, arguments.Parameters);
            }
            else
            {
                return Execute(arguments.Command);
            }
        }

        public static ActionResult Execute(string command)
        {
            if (!IsConnected)
            {
                return new ErrorResult("Application is not yet connected to host.");
            }

            if (command == BLOCK_COMMAND)
            {
                command = buildCommand();
            }

            return InspectProvider.ExecuteScript(command);
        }

        private static string buildCommand()
        {
            StringBuilder builder = new StringBuilder();

            bool exit = false;
            int count = 1;

            while (!exit)
            {
                System.Console.Write(string.Format(">> {0} ", count));
                string lineCommand = System.Console.ReadLine();
                if (lineCommand != BLOCK_COMMAND)
                {
                    builder.AppendLine(lineCommand);
                    count++;
                }
                else
                {
                    exit = true;
                }
            }

            return builder.ToString();
        }

        public static ActionResult Execute(string commandName, object parameter)
        {
            if (!string.IsNullOrWhiteSpace(commandName))
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
                if (_inspectorProvider == null)
                {
                    _inspectorProvider = Activator.GetObject(typeof(IInspectProvider), "ipc://Diagnostics/InspectorService") as IInspectProvider;
                }

                return _inspectorProvider;
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
                return string.Format("[{0}] > ", State.ToString());
            }
        }
    }
}
