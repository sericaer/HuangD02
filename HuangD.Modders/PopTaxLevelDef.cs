using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Modders
{
    internal class PopTaxLevelDef : IPopTaxLevelDef
    {
        public IEnumerable<IPopTaxLevelDef.Item> items { get; internal set; }
    }
}