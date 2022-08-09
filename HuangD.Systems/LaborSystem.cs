using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class LaborSystem
    {
        private Dictionary<IProvince.LaborLevel, ILaborCountEffectDef> dictLaborLevel;

        public LaborSystem(ILaborLevelDef def)
        {
            dictLaborLevel = def.items.SelectMany(x => x.effectDefs.OfType<ILaborCountEffectDef>().Select(effect => (x.level, effect)))
                .ToDictionary(key => key.level, value => value.effect);
        }

        public void Process(ILaborMgr laborMgr, IList<IProvince> provinces, IDate date)
        {
            foreach (var province in provinces)
            {
                var labor = province.labor;

                labor.baseValue = (int)(province.popCount * 0.05);
                labor.effects = province.buffers.SelectMany(x => x.def.effects.OfType<IMilitaryCountEffectDef>().Select(y => (x.def.name, y.Value)))
                    .Prepend(("劳役等级", dictLaborLevel[province.laborLevel].Value));

                if (!laborMgr.tables.ContainsKey(province))
                {
                    laborMgr.tables.Add(province, labor);

                    labor.currValue = labor.maxValue / 2;
                }

                if (date.day == 30)
                {
                    var incPerMonth = Math.Max(labor.maxValue / 4, 3);

                    if (labor.currValue < labor.maxValue)
                    {
                        labor.currValue = Math.Min(labor.currValue + incPerMonth, labor.maxValue);
                    }
                    else if (labor.currValue > labor.maxValue)
                    {
                        labor.currValue = labor.maxValue;
                    }
                }
            }
        }
    }
}
