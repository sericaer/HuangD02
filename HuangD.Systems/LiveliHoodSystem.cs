using HuangD.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class LiveliHoodSystem
    {
        private Dictionary<IProvince.PopTaxLevel, ILiveliHoodEffectDef> dictEffectByPopTaxLevel;

        public LiveliHoodSystem(IPopTaxLevelDef def)
        {
            dictEffectByPopTaxLevel = def.taxLevelEffectGroups.SelectMany(x => x.effectDefs.OfType<ILiveliHoodEffectDef>().Select(effect => (x.popTaxLevel, effect)))
                .ToDictionary(key => key.popTaxLevel, value => value.effect);
        }

        public void Process(IList<IProvince> provinces, IDate date)
        {
            foreach (var province in provinces)
            {
                province.livelihood.baseValue = 100;
                province.livelihood.effects = province.buffers.SelectMany(x => x.def.effects.OfType<ILiveliHoodEffectDef>().Select(y => (x.def.name, y.Value)))
                    .Prepend(("TaxLevel", CalcEffectValueByLevel(province.popTaxLevel)));
            }

        }

        private double CalcEffectValueByLevel(IProvince.PopTaxLevel popTaxLevel)
        {
            return dictEffectByPopTaxLevel[popTaxLevel].Value;
        }
    }
}
