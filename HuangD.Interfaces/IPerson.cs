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
        IParty party => toPartyRelations.SingleOrDefault()?.party;

        IEnumerable<IPerson2Office> toOfficeRelations { get; }
        IEnumerable<IPerson2Party> toPartyRelations { get; }
    }

    public interface IParty
    {
        string name { get; }
        IEnumerable<IPerson> persons { get; }
    }
}
