using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace RedSpect.Shared.Command
{
    [DataContract]
    [Serializable]
    public class CommandDetail
    {

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Help { get; set; }

        [DataMember]
        public string Usage { get; set; }

        public CommandDetail GetDetails()
        {
            return new CommandDetail() { Name = this.Name, Help = this.Help, Usage = this.Usage };
        }

    }
}
