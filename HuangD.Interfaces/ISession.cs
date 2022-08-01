using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Interfaces
{
    public interface ISession
    {
        public IPerson emperor { get; }
        public IDate date { get; }
        string yearName { get; }

        int popCount => provinces.Sum(x => x.popCount);

        public IList<IPerson> persons { get; }

        public IList<IParty> parties { get; }

        public IList<IProvince> provinces { get; }

        public IChaotingGroup chaoting { get; }

        public IHouGongGroup hougong { get; }


        IRelationMgr relationMgr { get; }

        void OnTimeElapse();

        IMoneyMgr moneyMgr { get; }
    }

    public interface IMoneyMgr
    {
        int current { get; set; }

        Dictionary<CollectType, Dictionary<object, Func<TaxItem>>> tables { get; }

        public enum CollectType
        {
            POPTAX,
        }

        public class TaxItem
        {
            public int baseValue { get; }
            public int Value => baseValue * (100 + effects.Sum(x => x.value)) / 100;

            public IEnumerable<(string desc, int value)> effects { get; }

            public TaxItem(int basValue, IEnumerable<(string desc, int value)> effects)
            {
                this.baseValue = basValue;
                this.effects = effects;
            }
        }
    }
}
