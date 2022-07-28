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
            public static IRelationMgr Build(IList<IPerson> persons, IChaotingGroup chaoting)
            {
                var relation = new RelationMgr();

                int i = 0;
                for(; i< chaoting.mainOffices.Count(); i++)
                {
                    relation.Person2OfficeStart(persons.ElementAt(i), chaoting.mainOffices.ElementAt(i), (1, 1, 1));
                }

                int j = 0;
                for (; j < chaoting.branchOffices.Count(); j++)
                {
                    relation.Person2OfficeStart(persons.ElementAt(j+i), chaoting.branchOffices.ElementAt(j), (1, 1, 1));
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
