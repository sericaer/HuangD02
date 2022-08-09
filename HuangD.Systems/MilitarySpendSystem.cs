using HuangD.Interfaces;

namespace HuangD.Systems
{
    public class MilitarySpendSystem
    {
        public void Process(IMilitaryMgr militaryMgr, IMoneyMgr moneyMgr, IDate date)
        {
            IMoneyMgr.SpendItem spendItem;

            if (!moneyMgr.spendTables.TryGetValue(militaryMgr, out spendItem))
            {
                spendItem = new IMoneyMgr.SpendItem()
                {
                    name = "军队维护"
                };

                moneyMgr.spendTables.Add(militaryMgr, spendItem);
            }

            spendItem.value = militaryMgr.current;

            if (date.day == 30)
            {
                moneyMgr.current -= spendItem.value;
            }
        }
    }
}
