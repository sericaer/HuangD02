using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Interfaces
{
    public interface IMilitaryMgr
    {
        int current { get; set; }

        Dictionary<object, Func<Item>> tables { get; }

        public enum CollectType
        {
            POPTAX,
        }

        public class Item
        {
            public int baseValue { get; }
            public double Value => baseValue * Math.Max(0, (100 + effects.Sum(x => x.value))) / 100;

            public IEnumerable<(string desc, double value)> effects { get; }

            public Item(int basValue, IEnumerable<(string desc, double value)> effects)
            {
                this.baseValue = basValue;
                this.effects = effects;
            }
        }
    }
}
