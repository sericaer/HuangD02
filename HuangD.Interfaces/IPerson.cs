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
        int power  => 10;
    }

    public interface IParty
    {
        string name { get; }
        int power => members.Sum(x => x.power);

        IEnumerable<IPerson> members => toPersonRelations.Select(x => x.person);
        IEnumerable< IPerson2Party> toPersonRelations { get; }
    }
}
