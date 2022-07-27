using HuangD.Entities;
using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Sessions
{
    public partial class Session : ISession
    {
        public IPerson emperor { get; private set; }

        public IDate date { get; private set; }

        public string yearName { get; private set; }

        public IRelationMgr relationMgr { get; private set; }

        public IList<IPerson> persons { get; private set; }

        public IChaotingGroup chaoting { get; private set; }

        public IHouGongGroup hougong { get; private set; }

        public Session()
        {
            Person.funcGetToOfficeRelations = (person) =>
            {
                return relationMgr.person2Offices.Where(x => x.person == person);
            };
        }

        public void OnTimeElapse()
        {
            date.day++;
        }
    }
}
