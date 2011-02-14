using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Client.Console.Commands;
using RedSpect.Shared.Interfaces;
using RedSpect.Shared.Contracts;
using System.IO;
using RedSpect.Shared;

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
        const string SCRIPT_COMMAND = ">!";

        private static Dictionary<string, ICommandGroup> _commandGroups = null;
        private static Dictionary<string, ICommand> _commands = null;
        private static bool _isConnected = false;
        private static ICommandRunner _inspectorProvider = null;

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

            if (command.StartsWith(SCRIPT_COMMAND))
            {
                string file = command.Remove(0, 2).Trim();

                command = loadCommand(file);
            }

            try
            {
                return InspectProvider.ExecuteScript(command);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }

        private static string loadCommand(string file)
        {
            string command = null;

            using(var reader = new StreamReader(file))
            {
                command = reader.ReadToEnd();
                reader.Close();
            }

            return command;
        }

        private static string buildCommand()
        {
            StringBuilder builder = new StringBuilder();

            bool exit = false;
            int count = 1;

            while (!exit)
            {
                //TODO: apply polymorphism pattern
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

        public static ActionResult Connect(string connectionId, params string[] args)
        {
            ResultBuilder builder = new ResultBuilder();

            if (!IsConnected)
            {
                initializeConnection(connectionId, args);

                if (InspectProvider != null)
                {
                    builder.WriteLine(string.Format("Connected -> {0}", InspectProvider.HostDetails()));
                    _isConnected = true;
                }
                else
                {
                    return new ErrorResult("Error connecting to host.");
                }
            }
            else
            {
                builder.WriteLine("Already connected.");
            }

            return builder.CreateResult(null);
        }

        private static void initializeConnection(string connectionId, string[] arguments)
        {
            _inspectorProvider = ProbeFactory.Create(connectionId.ToLower(), arguments);
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

        protected static ICommandRunner InspectProvider
        {
            get
            {
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

        public static ActionResult GetCommand(string commandName)
        {


            if (_commands.ContainsKey(commandName))
            {
                ResultBuilder builder = new ResultBuilder();

                var detail = _commands[commandName] as CommandDetail;

                if (detail != null)
                {
                    displayCommand(builder, detail);
                }

                return builder.CreateResult();
            }
            else if (IsConnected && InspectProvider.ContainsCommand(commandName))
            {
                ResultBuilder builder = new ResultBuilder();

                var commands = InspectProvider.GetCommands();

                var detail = commands.FirstOrDefault(command => command.Name.ToLower() == commandName);

                if (detail != null)
                {
                    displayCommand(builder, detail);
                }

                return builder.CreateResult();
            }
            else
            {
                return new ErrorResult("Command not found.");
            }
        }


        private static void displayCommand(ResultBuilder builder, CommandDetail detail)
        {
            builder.WriteLine();
            builder.WriteLine(string.Format("COMMAND: {0}", detail.Name));
            builder.WriteLine(string.Format("   {0}", detail.Help));
            builder.WriteLine();
            builder.WriteLine(string.Format("USAGE: {0}", detail.Usage));
        }

        public static ActionResult GetCommand()
        {
            ResultBuilder builder = new ResultBuilder();

            builder.WriteLine("Local Commands");
            builder.WriteLine("====================");
            foreach (string key in _commands.Keys)
            {
                var detail = _commands[key] as CommandDetail;

                if (detail != null)
                {
                    builder.WriteLine(string.Format("{0}# {1}", detail.Name.PadRight(20), detail.Help));
                }
            }

            if (IsConnected)
            {
                builder.WriteLine();
                builder.WriteLine("Remote Commands");
                builder.WriteLine("====================");
                var commands = InspectProvider.GetCommands();
                foreach (var command in commands)
                {
                    builder.WriteLine(string.Format("{0}# {1}", command.Name.PadRight(20), command.Help));
                }
            }

            return builder.CreateResult();
        }
    }
}
