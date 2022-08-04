using HuangD.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class PopCountIncreaseSystem
    {
        private Dictionary<IProvince, List<(string, double)>> dict = new Dictionary<IProvince, List<(string, double)>>();

        public void Process(IList<IProvince> provinces, IDate date)
        {
            foreach (var province in provinces)
            {
                if (!dict.ContainsKey(province))
                {
                    dict.Add(province, new List<(string, double)>());
                    province.popCountChange.effects = dict[province];
                }

                dict[province].Clear();
                dict[province].Add(("基础值", 0.5));
                dict[province].AddRange(province.buffers.SelectMany(x => x.def.effects.OfType<IPopIncreaseEffectDef>().Select(y => (x.def.name, y.Value))));

                if (date.day == 30)
                {
                    province.popCount += (int)(province.popCount * province.popCountChange.effects.Sum(x => x.value) / 100);
                }
            }
        }
    }
}
