using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Modders
{
    internal class PopTaxLevelDef : IPopTaxLevelDef
    {
        public Dictionary<IProvince.PopTaxLevel, int> dictLevelEffect { get; internal set; }
    }
}