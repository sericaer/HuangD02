﻿using System.Collections.Generic;
using System.Linq;

namespace HuangD.Interfaces
{
    public interface IOffice
    {
        string name { get; }

        IOfficeDef def { get; }
        IEnumerable<IPerson2Office> toPersonRelations { get; }
        IPerson currPerson => toPersonRelations.SingleOrDefault(x => x.isCurrent)?.person;
    }
}
