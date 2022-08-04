using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Interfaces
{
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
            public double Value => baseValue * Math.Max(0, (100 + effects.Sum(x => x.value))) / 100;

            public IEnumerable<(string desc, double value)> effects { get; }

            public TaxItem(int basValue, IEnumerable<(string desc, double value)> effects)
            {
                this.baseValue = basValue;
                this.effects = effects;
            }
        }
    }
}
