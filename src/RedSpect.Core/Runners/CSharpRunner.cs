using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using RedSpect.Shared;

namespace RedSpect.Core.Runners
{
    [Export(typeof(IRunner))]
    public class CSharpRunner : IRunner
    {

        const string SUPPORTED_TYPE = "cs";

        Dictionary<string, Func<string[], object>> _csharpCommands;

        public CSharpRunner()
        {
            Initialize();
        }

        [ImportMany]
        public ICommandSet[] CommandProviders { get; set; }

        public void Initialize()
        {
            DirectoryCatalog catalog = new DirectoryCatalog("./");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            _csharpCommands = new Dictionary<string, Func<string[], object>>();

            if (CommandProviders != null)
            {
                foreach (var provider in CommandProviders)
                {
                    var commandSet = provider.GetCommands();

                    foreach (string key in commandSet.Keys)
                    {
                        _csharpCommands.Add(key, commandSet[key]);
                    }
                }
            }
        }

        public string SupportedType
        {
            get { return SUPPORTED_TYPE; }
        }

        public object Execute(ExecutionContext context)
        {
            if (CanExecute(context))
            {
                return _csharpCommands[context.Command](context.Arguments);
            }

            throw new InvalidOperationException("Command not found.");
        }

        public bool CanExecute(ExecutionContext context)
        {
            return _csharpCommands.ContainsKey(context.Command);
        }

    }
}
