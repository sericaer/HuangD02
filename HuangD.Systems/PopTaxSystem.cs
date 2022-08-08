using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class PopTaxSystem
    {
        private Dictionary<IProvince.PopTaxLevel, IPopTaxEffectDef> dictEffectByPopTaxLevel;

        public PopTaxSystem(IPopTaxLevelDef def)
        {
            dictEffectByPopTaxLevel = def.items.SelectMany(x => x.effectDefs.OfType<IPopTaxEffectDef>().Select(effect => (x.popTaxLevel, effect)))
                .ToDictionary(key => key.popTaxLevel, value => value.effect);
        }

        public void Process(IMoneyMgr moneyMgr, IList<IProvince> provinces, IDate date)
        {
            foreach (var province in provinces)
            {
                if (!moneyMgr.tables[IMoneyMgr.CollectType.POPTAX].ContainsKey(province))
                {
                    moneyMgr.tables[IMoneyMgr.CollectType.POPTAX].Add(province, () => CalcTaxItem(province));
                }
            }
        }

        private IMoneyMgr.TaxItem CalcTaxItem(IProvince province)
        {
            var taxItem = new IMoneyMgr.TaxItem(
                (int)(province.popCount * 0.1),
                province.buffers.SelectMany(x => x.def.effects.OfType<IPopTaxEffectDef>().Select(y=>(x.def.name, y.Value)))
                                .Prepend(("TaxLevel", CalcEffectValueByLevel(province.popTaxLevel))));

            return taxItem;
        }

        private double CalcEffectValueByLevel(IProvince.PopTaxLevel popTaxLevel)
        {
            return dictEffectByPopTaxLevel[popTaxLevel].Value;
        }
    }
}
