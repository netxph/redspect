using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedSpect.Tests
{
    public abstract class BaseCommandSet : ICommandSet
    {
        public virtual Dictionary<string, Func<string[], object>> GetCommands()
        {
            var results = new Dictionary<string, Func<string[], object>>();

            var methods = this.GetType().GetMethods();

            foreach (var method in methods)
            {
                var command = method.GetCustomAttributes(typeof(CommandAttribute), true).FirstOrDefault() as CommandAttribute;

                if (command != null)
                {
                    Func<string[], object> action = (Func<string[], object>)Delegate.CreateDelegate(typeof(Func<string[], object>), this, method);
                    command.ActionCommand = action;

                    results.Add(command.Name, command.ActionCommand);
                }
            }

            return results;
        }
    }
}
