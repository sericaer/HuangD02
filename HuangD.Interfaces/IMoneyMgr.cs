using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Interfaces
{
    public interface IMoneyMgr
    {
        int current { get; set; }

        Dictionary<CollectType, Dictionary<object, ITaxItem>> incomeTables { get; }

        Dictionary<object, IMoneyMgr.SpendItem> spendTables { get; }

        public enum CollectType
        {
            POPTAX,
        }

        public interface ITaxItem
        {
            public int Value { get; }

            public int baseValue { get;  }
            public IEnumerable<(string desc, double value)> effects { get; }
        }

        public class SpendItem
        {
            public string name { get; set; }
            public int value { get; set; }
        }
    }
}
