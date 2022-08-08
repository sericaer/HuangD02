using HuangD.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class LiveliHoodSystem
    {
        private Dictionary<IProvince.PopTaxLevel, ILiveliHoodEffectDef> dictPopTaxLevel;
        private Dictionary<IProvince.MilitaryLevel, ILiveliHoodEffectDef> dictMilitaryLevel;

        public LiveliHoodSystem(IPopTaxLevelDef popTaxLevelDef, IMilitaryLevelDef militaryLevelDef)
        {
            dictPopTaxLevel = popTaxLevelDef.items.SelectMany(x => x.effectDefs.OfType<ILiveliHoodEffectDef>().Select(effect => (x.popTaxLevel, effect)))
                .ToDictionary(key => key.popTaxLevel, value => value.effect);

            dictMilitaryLevel = militaryLevelDef.items.SelectMany(x => x.effectDefs.OfType<ILiveliHoodEffectDef>().Select(effect => (x.level, effect)))
                .ToDictionary(key => key.level, value => value.effect);
        }

        public void Process(IList<IProvince> provinces, IDate date)
        {
            foreach (var province in provinces)
            {
                province.livelihood.baseValue = 100;
                province.livelihood.effects = province.buffers.SelectMany(x => x.def.effects.OfType<ILiveliHoodEffectDef>().Select(y => (x.def.name, y.Value)))
                    .Prepend(("人口税", dictPopTaxLevel[province.popTaxLevel].Value))
                    .Prepend(("兵役", dictMilitaryLevel[province.militaryLevel].Value));
            }

        }
    }
}
