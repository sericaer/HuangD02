using HuangD.Entities;
using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class MilitarySystem
    {
        private Dictionary<IProvince.MilitaryLevel, IMilitaryCountEffectDef> dictMilitaryLevel;

        public MilitarySystem(IMilitaryLevelDef def, IMilitaryMgr militaryMgr, IList<IProvince> provinces)
        {
            dictMilitaryLevel = def.items.SelectMany(x => x.effectDefs.OfType<IMilitaryCountEffectDef>().Select(effect => (x.level, effect)))
                .ToDictionary(key => key.level, value => value.effect);

            foreach (var province in provinces)
            {
                var military = province.military as MilitaryItem;

                military.GetBaseValue = ()=> (int)(province.popCount * 0.03);
                military.GetEffect = ()=> province.buffers.SelectMany(x => x.def.effects.OfType<IMilitaryCountEffectDef>().Select(y => (x.def.name, y.Value)))
                    .Prepend(("兵役等级", dictMilitaryLevel[province.militaryLevel].Value));
                military.currValue = military.maxValue / 2;

                militaryMgr.tables.Add(province, military);
            }
        }

        public void Process(IMilitaryMgr militaryMgr, IDate date)
        {
            foreach (var military in militaryMgr.tables.Values)
            {
                if (date.day == 30 )
                {
                    var incPerMonth = Math.Max(military.maxValue / 4, 3);

                    if (military.currValue < military.maxValue)
                    {
                        military.currValue = Math.Min(military.currValue + incPerMonth, military.maxValue);
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
