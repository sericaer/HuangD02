using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Systems
{
    public class PopTaxSystem
    {
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
            var taxItem = new IMoneyMgr.TaxItem((int)(province.popCount * 0.01));

            return taxItem;

        }
    }
}
