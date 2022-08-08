using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Interfaces
{
    public interface IMilitaryMgr
    {
        int current { get; }
        int max { get; }

        Dictionary<object, Item> tables { get; }

        public class Item
        {
            public int baseValue { get; set; }
            public double currValue { get; set; }
            public double maxValue => baseValue * Math.Max(0, (100 + effects.Sum(x => x.value))) / 100;
            public IEnumerable<(string desc, double value)> effects { get; set; }
  
        }
    }
}
