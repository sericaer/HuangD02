using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.Entities.Offices
{
    public abstract class Office : IOffice
    {
        public static Func<IOffice, IEnumerable<IPerson2Office>> funcGetToPersonRelations;

        public string name { get; internal set; }

        public IEnumerable<IPerson2Office> toPersonRelations => funcGetToPersonRelations(this);
    }
}
