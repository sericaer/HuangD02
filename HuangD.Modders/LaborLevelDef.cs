using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Modders
{
    internal class LaborLevelDef : ILaborLevelDef
    {
        public IEnumerable<ILaborLevelDef.Item> items { get; internal set; }
    }
}