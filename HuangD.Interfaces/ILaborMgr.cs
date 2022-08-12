using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Interfaces
{
    public interface ILaborMgr
    {
        int current { get; }
        int max { get; }

        Dictionary<object, IItem> tables { get; }

        public interface IItem
        {
            public int baseValue { get; }
            public int currValue { get; set; }
            public int maxValue { get; }
            public IEnumerable<(string desc, double value)> effects { get; }

        }
    }
}
