using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Modders
{
    internal class PopTaxLevelDef : IPopTaxLevelDef
    {
        public Dictionary<IProvince.PopTaxLevel, int> dictLevelPopTaxEffect { get; internal set; }

        public IEnumerable<IPopTaxLevelDef.TaxLevelEffectGroup> taxLevelEffectGroups { get; internal set; }
    }
}