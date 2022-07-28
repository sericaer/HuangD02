using HuangD.Interfaces;
using System;
using System.Collections.Generic;

namespace HuangD.Sessions
{
    internal class Party : IParty
    {
        public static Func<object, IEnumerable<IPerson2Party>> funcGetToPersonRelations;

        public string name => def.name;

        public IEnumerable<IPerson2Party> toPersonRelations => funcGetToPersonRelations(this);

        private IPartyDef def;

        public Party(IPartyDef def)
        {
            this.def = def;
        }


    }
}