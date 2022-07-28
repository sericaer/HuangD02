using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Relations
{
    public partial class RelationMgr
    {
        public static class Builder
        {
            public static IRelationMgr Build(IList<IPerson> persons, IChaotingGroup chaoting, IHouGongGroup houGongGroup, IList<IParty> parties)
            {
                var relation = new RelationMgr();

                BuildPerson2OfficeRelations(relation, persons, chaoting, houGongGroup);
                BuildPerson2PartyRelations(relation, persons, parties);
                return relation;
            }

            private static void BuildPerson2PartyRelations(RelationMgr relation, IEnumerable<IPerson> persons, IList<IParty> parties)
            {
                for(int i=0; i< persons.Count(); i++)
                {
                    relation.person2Parties.Add(new Person2Pary(persons.ElementAt(i), parties.ElementAt(i% parties.Count())));
                }
            }

            private static void BuildPerson2OfficeRelations(RelationMgr relation, IEnumerable<IPerson> persons, IChaotingGroup chaoting, IHouGongGroup houGongGroup)
            {
                var queue = new Queue<IPerson>(persons);
                for (int i = 0; i < chaoting.mainOffices.Count(); i++)
                {
                    relation.Person2OfficeStart(queue.Dequeue(), chaoting.mainOffices.ElementAt(i), (1, 1, 1));
                }

                for (int i = 0; i < chaoting.branchOffices.Count(); i++)
                {
                    relation.Person2OfficeStart(queue.Dequeue(), chaoting.branchOffices.ElementAt(i), (1, 1, 1));
                }

                foreach (var office in houGongGroup)
                {
                    relation.Person2OfficeStart(queue.Dequeue(), office, (1, 1, 1));
                }
            }
        }

        private void Person2OfficeStart(IPerson person, IOffice office, (int year, int month, int day) date)
        {
            person2Offices.Add(new Person2Office(person, office, date));
        }
    }
}
