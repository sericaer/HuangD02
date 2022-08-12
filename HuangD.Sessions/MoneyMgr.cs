using HuangD.Interfaces;
using System;
using System.Collections.Generic;

namespace HuangD.Sessions
{
    internal class MoneyMgr : IMoneyMgr
    {
        public int current { get; set; }

        public Dictionary<IMoneyMgr.CollectType, Dictionary<object, IMoneyMgr.ITaxItem>> incomeTables { get; }
        public Dictionary<object, IMoneyMgr.SpendItem> spendTables { get; }

        public MoneyMgr(int money)
        {
            current = money;

            incomeTables = new Dictionary<IMoneyMgr.CollectType, Dictionary<object, IMoneyMgr.ITaxItem>>();
            spendTables = new Dictionary<object, IMoneyMgr.SpendItem>();

            foreach (IMoneyMgr.CollectType elem in Enum.GetValues(typeof(IMoneyMgr.CollectType)))
            {
                incomeTables.Add(elem, new Dictionary<object, IMoneyMgr.ITaxItem>());
            }
        }

    }
}