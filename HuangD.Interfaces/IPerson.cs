using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuangD.Interfaces
{
    public interface IPerson
    {
        string fullName => familyName + givenName;

        string familyName { get; }
        string givenName { get; }
        IOffice currOffice => toOfficeRelations.SingleOrDefault(x => x.isCurrent)?.office;
        IEnumerable<IPerson2Office> toOfficeRelations { get; }
    }
}
