using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Modders
{
    class ModDefs : IModDefs
    {
        public IEnumerable<IOfficeDef> officeDefs { get; internal set; }

        public IPersonDef personDef { get; internal set; }

        public IEnumerable<IPartyDef> partyDefs { get; internal set; }

        public IEnumerable<IProvinceDef> provinceDefs { get; internal set; }
    }
}