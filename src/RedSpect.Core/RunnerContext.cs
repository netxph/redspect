using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using RedSpect.Shared;

namespace RedSpect.Core
{
    public class RunnerContext
    {

        public RunnerContext()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            DirectoryCatalog catalog = new DirectoryCatalog("./");
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        [ImportMany]
        public IRunner[] Runners { get; set; }

    }
}
