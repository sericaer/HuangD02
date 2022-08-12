using HuangD.Entities;
using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class PopTaxSystem
    {
        private Dictionary<IProvince.PopTaxLevel, IPopTaxEffectDef> dictPopTaxLevel;

        public PopTaxSystem(IPopTaxLevelDef def, IMoneyMgr moneyMgr, IList<IProvince> provinces)
        {
            dictPopTaxLevel = def.items.SelectMany(x => x.effectDefs.OfType<IPopTaxEffectDef>().Select(effect => (x.popTaxLevel, effect)))
                .ToDictionary(key => key.popTaxLevel, value => value.effect);

            foreach (var province in provinces)
            {
                var popTax = province.popTax as TaxItem;

                popTax.GetBaseValue = () => (int)(province.popCount * 0.1);
                popTax.GetEffect = () => province.buffers.SelectMany(x => x.def.effects.OfType<IPopTaxEffectDef>().Select(y => (x.def.name, y.Value)))
                                .Prepend(("人口税等级", dictPopTaxLevel[province.popTaxLevel].Value));

                moneyMgr.incomeTables[IMoneyMgr.CollectType.POPTAX].Add(province, popTax);
            }
        }

        public void Process(IMoneyMgr moneyMgr, IList<IProvince> provinces, IDate date)
        {
            //foreach (var province in provinces)
            //{
            //    var popTax = province.popTax as TaxItem;

            //    popTax.GetBaseValue = ()=> (int)(province.popCount * 0.1);
            //    popTax.GetEffect = ()=> province.buffers.SelectMany(x => x.def.effects.OfType<IPopTaxEffectDef>().Select(y => (x.def.name, y.Value)))
            //                    .Prepend(("人口税等级", dictPopTaxLevel[province.popTaxLevel].Value));

            //    if (!moneyMgr.incomeTables[IMoneyMgr.CollectType.POPTAX].ContainsKey(province))
            //    {
            //        moneyMgr.incomeTables[IMoneyMgr.CollectType.POPTAX].Add(province, popTax);
            //    }
            //}
        }
    }
}
