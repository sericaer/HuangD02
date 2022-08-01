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

        IEnumerable<(string desc, int value)> powerDetail { get; }
        IEnumerable<ScoreItem> scoreItems { get; }
        IEnumerable<IPerson2Office> toOfficeRelations { get; }
        IEnumerable<IPerson2Party> toPartyRelations { get; }

        int power => powerDetail.Sum(x => x.value);
        int? score => scoreItems?.Sum(x => x.value);

        IOffice currOffice => toOfficeRelations.SingleOrDefault(x => x.isCurrent)?.office;
        IParty party => toPartyRelations.SingleOrDefault()?.party;

        class ScoreItem
        {
            public readonly (int y, int m, int d) date;
            public readonly string desc;
            public readonly int value;

            public ScoreItem(IDate date, string desc, int value)
            {
                this.date = (date.year, date.month, date.day);
                this.desc = desc;
                this.value = value;
            }
        }
    }

    public interface IParty
    {
        string name { get; }
        int power => members.Sum(x => x.power);

        IEnumerable<IPerson> members => toPersonRelations.Select(x => x.person);
        IEnumerable< IPerson2Party> toPersonRelations { get; }
    }
}
