using LogicSimEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuangD.Interfaces
{
    public interface IProvince : IBufferOwner
    {
        string name { get; }
        IOffice masterOffice { get; }
        int popCount { get; }
        IMoneyMgr.TaxItem popTax { get; }

        LiveliHood livelihood { get; }

        PopTaxLevel popTaxLevel { get; set; }

        //List<IBuffer> buffers { get; }

        public enum PopTaxLevel
        {
            VeryLow,
            Low,
            Mid,
            High,
            VeryHigh
        }

        public class LiveliHood
        {
            public int baseValue { get; set; }
            public int Value => baseValue * (100 + effects.Sum(x => x.value)) / 100;
            public IEnumerable<(string desc, int value)> effects { get; set; }
        }
    }
}
