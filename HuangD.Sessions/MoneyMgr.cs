using HuangD.Interfaces;
using System;
using System.Collections.Generic;

namespace HuangD.Sessions
{
    internal class MoneyMgr : IMoneyMgr
    {
        public int current { get; set; }

        public Dictionary<IMoneyMgr.CollectType, Dictionary<object, IMoneyMgr.TaxItem>> tables { get; }

        public MoneyMgr(int money)
        {
            current = money;
            tables = new Dictionary<IMoneyMgr.CollectType, Dictionary<object, IMoneyMgr.TaxItem>>();

            foreach(IMoneyMgr.CollectType elem in Enum.GetValues(typeof(IMoneyMgr.CollectType)))
            {
                tables.Add(elem, new Dictionary<object, IMoneyMgr.TaxItem>());
            }
        }

    }
}