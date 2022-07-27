using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.Entities.Offices
{
    public class Office : IOffice
    {
        public static Func<IOffice, IEnumerable<IPerson2Office>> funcGetToPersonRelations;

        public string name => def.name;

        public IEnumerable<IPerson2Office> toPersonRelations => funcGetToPersonRelations(this);

        public IOfficeDef def { get; }

        public Office()
        {

        }

        public Office(IOfficeDef def)
        {
            this.def = def;
        }
    }
}
