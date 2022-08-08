using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Modders
{
    internal class MilitaryLevelDef : IMilitaryLevelDef
    {
        public IEnumerable<IMilitaryLevelDef.Item> items { get; internal set; }
    }
}