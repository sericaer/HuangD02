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
            public static IRelationMgr Build(IList<IPerson> persons, IChaotingGroup chaoting, IHouGongGroup houGongGroup)
            {
                var relation = new RelationMgr();

                var queue = new Queue<IPerson>(persons);
                for(int i =0; i < chaoting.mainOffices.Count(); i++)
                {
                    relation.Person2OfficeStart(queue.Dequeue(), chaoting.mainOffices.ElementAt(i), (1, 1, 1));
                }

                for (int i = 0; i < chaoting.branchOffices.Count(); i++)
                {
                    relation.Person2OfficeStart(queue.Dequeue(), chaoting.branchOffices.ElementAt(i), (1, 1, 1));
                }

                foreach(var office in houGongGroup)
                {
                    relation.Person2OfficeStart(queue.Dequeue(), office, (1, 1, 1));
                }

                return relation;
            }
        }

        private void Person2OfficeStart(IPerson person, IOffice office, (int year, int month, int day) date)
        {
            person2Offices.Add(new Person2Office(person, office, date));
        }
    }
}
