using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Reflection;
using RedSpect.Shared.Interfaces;

namespace RedSpect.Shared.Command
{
    public abstract class CommandGroupBase : ICommandGroup
    {
        

        Dictionary<string, ICommand> _commands = null;

        public abstract string Name { get; }

        public Dictionary<string, ICommand> Commands 
        {
            get
            {
                if (_commands == null)
                {
                    _commands = OnGetLocalCommands();
                }

                return _commands;
            }
        }

        protected void Initialize()
        {
            _commands = OnGetLocalCommands();
        }

        protected virtual Dictionary<string, ICommand> OnGetLocalCommands()
        {
            Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

            var methods = this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(CommandAttribute), false);
                
                if (attributes.Length > 0)
                {
                    foreach (var attribute in attributes)
                    {
                        commands.Add(((CommandAttribute)attribute).Name.ToLower(), new RelayCommand((Action<object>)Delegate.CreateDelegate(typeof(Action<object>), this, method)));
                    }
                }
            }

            return commands;
        }


        public virtual void Test()
        {
            System.Console.WriteLine(string.Format("[{0}] Command group is enabled.", Name));
        }
        
    }
}
