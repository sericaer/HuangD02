using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Interfaces
{
    public interface IMoneyMgr
    {
        int current { get; set; }

        Dictionary<CollectType, Dictionary<object, TaxItem>> tables { get; }

        public enum CollectType
        {
            POPTAX,
        }

        public class TaxItem
        {
            public int Value => (int)(baseValue * Math.Max(0, (100 + effects.Sum(x => x.value))) / 100);

            public int baseValue { get; set; }
            public IEnumerable<(string desc, double value)> effects { get; set; }
        }
    }
}
