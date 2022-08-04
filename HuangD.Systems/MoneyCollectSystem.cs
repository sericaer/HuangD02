using HuangD.Interfaces;
using System.Linq;

namespace HuangD.Systems
{
    public class MoneyCollectSystem
    {
        public void Process(IMoneyMgr moneyMgr, IDate date)
        {
            if (date.day == 30)
            {
                moneyMgr.current += (int)moneyMgr.tables.Sum(x => x.Value.Sum(y => y.Value().Value));
            }
        }
    }
}
