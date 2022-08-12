using HuangD.Entities;
using HuangD.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class LiveliHoodSystem
    {
        private Dictionary<IProvince.PopTaxLevel, ILiveliHoodEffectDef> dictPopTaxLevel;
        private Dictionary<IProvince.MilitaryLevel, ILiveliHoodEffectDef> dictMilitaryLevel;
        private Dictionary<IProvince.LaborLevel, ILiveliHoodEffectDef> dictLaborLevel;

        public LiveliHoodSystem(IModDefs modDefs, IList<IProvince> provinces)
        {
            dictPopTaxLevel = modDefs.popTaxLevelDef.items.SelectMany(x => x.effectDefs.OfType<ILiveliHoodEffectDef>().Select(effect => (x.popTaxLevel, effect)))
                .ToDictionary(key => key.popTaxLevel, value => value.effect);

            dictMilitaryLevel = modDefs.militaryLevelDef.items.SelectMany(x => x.effectDefs.OfType<ILiveliHoodEffectDef>().Select(effect => (x.level, effect)))
                .ToDictionary(key => key.level, value => value.effect);

            dictLaborLevel = modDefs.laborLevelDef.items.SelectMany(x => x.effectDefs.OfType<ILiveliHoodEffectDef>().Select(effect => (x.level, effect)))
                .ToDictionary(key => key.level, value => value.effect);

            foreach (var province in provinces)
            {
                var livelihood = province.livelihood as LiveliHood;

                livelihood.GetBaseValue = ()=> 100;
                livelihood.GetEffect = ()=> province.buffers.SelectMany(x => x.def.effects.OfType<ILiveliHoodEffectDef>().Select(y => (x.def.name, y.Value)))
                    .Prepend(("劳役", dictLaborLevel[province.laborLevel].Value))
                    .Prepend(("兵役", dictMilitaryLevel[province.militaryLevel].Value))
                    .Prepend(("人口税", dictPopTaxLevel[province.popTaxLevel].Value));
            }
        }
    }
}
