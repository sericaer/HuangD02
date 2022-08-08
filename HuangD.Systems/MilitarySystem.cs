using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class MilitarySystem
    {
        private Dictionary<IProvince.MilitaryLevel, IMilitaryCountEffectDef> dictMilitaryLevel;

        public MilitarySystem(IMilitaryLevelDef def)
        {
            dictMilitaryLevel = def.items.SelectMany(x => x.effectDefs.OfType<IMilitaryCountEffectDef>().Select(effect => (x.level, effect)))
                .ToDictionary(key => key.level, value => value.effect);
        }

        public void Process(IMilitaryMgr militaryMgr, IList<IProvince> provinces, IDate date)
        {
            foreach (var province in provinces)
            {
                var military = province.military;

                military.baseValue = (int)(province.popCount * 0.1);
                military.effects = province.buffers.SelectMany(x => x.def.effects.OfType<IMilitaryCountEffectDef>().Select(y => (x.def.name, y.Value)))
                    .Prepend(("兵役等级", dictMilitaryLevel[province.militaryLevel].Value));
                
                if (!militaryMgr.tables.ContainsKey(province))
                {
                    militaryMgr.tables.Add(province, military);

                    military.currValue = military.maxValue / 2;
                }


                if (date.day == 30 )
                {
                    if (military.currValue < military.maxValue)
                    {
                        military.currValue = Math.Min(military.currValue + 30 * 10, military.maxValue);
                    }
                    else if (military.currValue > military.maxValue)
                    {
                        military.currValue = military.maxValue;
                    }
                }
            }
        }
    }
}
