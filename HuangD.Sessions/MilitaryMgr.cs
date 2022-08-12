using HuangD.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Sessions
{
    internal class MilitaryMgr : IMilitaryMgr
    {
        public int current => (int)tables.Values.Sum(x => x.currValue);
        public int max => (int)tables.Values.Sum(x => x.maxValue);

        public Dictionary<object, IMilitaryMgr.IItem> tables { get; } = new Dictionary<object, IMilitaryMgr.IItem>();


    }
}