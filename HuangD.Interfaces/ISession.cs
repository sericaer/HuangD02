using System;
using System.Collections.Generic;

namespace HuangD.Interfaces
{
    public interface ISession
    {
        public IPerson emperor { get; }
        public IDate date { get; }
        string yearName { get; }

        public IList<IPerson> persons { get; }

        public IList<IParty> parties { get; }

        public IList<IProvince> provinces { get; }
        public IChaotingGroup chaoting { get; }

        public IHouGongGroup hougong { get; }


        IRelationMgr relationMgr { get; }

        void OnTimeElapse();


    }
}
