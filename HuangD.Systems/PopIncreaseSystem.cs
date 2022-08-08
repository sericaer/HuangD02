using HuangD.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class PopIncreaseSystem
    {
        public void Process(IList<IProvince> provinces, IDate date)
        {
            foreach (var province in provinces)
            {
                province.popCountChange.effects = province.buffers.SelectMany(x => x.def.effects.OfType<IPopIncreaseEffectDef>().Select(y => (x.def.name, y.Value))).Prepend(("基础值", 0.1));

                if (date.day == 30)
                {
                    province.popCount += (int)(province.popCount * province.popCountChange.effects.Sum(x => x.value) / 100);
                }
            }
        }
    }
}
