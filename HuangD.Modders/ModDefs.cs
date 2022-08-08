using HuangD.Interfaces;
using LogicSimEngine.Interfaces;
using System.Collections.Generic;

namespace HuangD.Modders
{
    class ModDefs : IModDefs
    {
        public IEnumerable<IOfficeDef> officeDefs { get; internal set; }

        public IPersonDef personDef { get; internal set; }

        public IEnumerable<IPartyDef> partyDefs { get; internal set; }

        public IEnumerable<IProvinceDef> provinceDefs { get; internal set; }

        public ICountryDef countryDef { get; internal set; }

        public IPopTaxLevelDef popTaxLevelDef { get; internal set; }

        public IMilitaryLevelDef militaryLevelDef  { get; internal set; }

        public ILaborLevelDef laborLevelDef { get; internal set; }

        public IEnumerable<IBufferDef> bufferDefs { get; internal set; }
    }
}