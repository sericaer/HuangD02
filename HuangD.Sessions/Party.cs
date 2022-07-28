using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Sessions
{
    internal class Party : IParty
    {
        public string name => def.name;

        public IEnumerable<IPerson> persons => throw new System.NotImplementedException();

        private IPartyDef def;

        public Party(IPartyDef def)
        {
            this.def = def;
        }


    }
}