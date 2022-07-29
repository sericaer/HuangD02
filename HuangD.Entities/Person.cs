using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Entities
{
    public partial class Person : IPerson
    {
        public static Func<IPerson, IEnumerable<IPerson2Office>> funcGetToOfficeRelations;
        public static Func<IPerson, IEnumerable<IPerson2Party>> funcGetToPartyRelations;
        public static Func<IPerson, IEnumerable<IPerson.ScoreItem>> funcGetScoreItems;

        public string familyName { get; private set; }
        public string givenName { get; private set; }

        public IEnumerable<IPerson2Office> toOfficeRelations => funcGetToOfficeRelations(this);

        public IEnumerable<IPerson2Party> toPartyRelations => funcGetToPartyRelations(this);

        public IEnumerable<(string desc, int value)> powerDetail => toOfficeRelations.Where(x => x.isCurrent)
            .Select(x => x.office.def).OfType<IChaotingOfficeDef>().Select(x => (x.name, x.power));

        public IEnumerable<IPerson.ScoreItem> scoreItems => funcGetScoreItems(this);

        public Person((string family, string given) name)
        {
            familyName = name.family;
            givenName = name.given;
        }
    }
}
