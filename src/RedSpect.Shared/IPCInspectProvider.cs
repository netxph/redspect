using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedSpect.Shared.Interfaces;
using System.Reflection;
using System.IO;
using RedSpect.Shared.Command;

namespace RedSpect.Shared
{
    public class IPCInspectProvider : MarshalByRefObject, IInspectProvider
    {
        private Dictionary<string, ICommand> _commands = null;

        public string HostDetails()
        {
            return string.Format("{0} => {1}", Environment.MachineName, Path.GetFileName(Assembly.GetEntryAssembly().Location));
        }

        public void TestCommandSet(string name)
        {
            ApplicationProbe.InspectorCommands[name].Test();
        }

        protected IDictionary<string, ICommand> Commands
        {
            get 
            {
                if (_commands == null)
                {
                    _commands = getCommands();
                }

                return _commands;
            }
        }

        private Dictionary<string, ICommand> getCommands()
        {
            Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

            foreach (var commandGroup in ApplicationProbe.InspectorCommands.Values)
            {
                foreach (string key in commandGroup.Commands.Keys)
                {
                    commands.Add(key, commandGroup.Commands[key]);
                }
            }

            return commands;
        }

        public ActionResult Execute(string commandName, object parameter)
        {
            if (!string.IsNullOrEmpty(commandName))
            {
                if (Commands.ContainsKey(commandName))
                {
                    return Commands[commandName].Execute(parameter);
                }
            }

            return null;
        }

        public bool ContainsCommand(string commandName)
        {
            return Commands.ContainsKey(commandName);
        }
    }
}
