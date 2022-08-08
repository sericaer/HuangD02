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
        int popCount { get; set; }
        IMoneyMgr.TaxItem popTax { get; }
        IMilitaryMgr.Item military { get; }

        LiveliHood livelihood { get; }

        PopTaxLevel popTaxLevel { get; set; }
        MilitaryLevel militaryLevel { get; set; }
        LaborLevel laborLevel { get; set; }
        PopCountChange popCountChange { get; }

        //List<IBuffer> buffers { get; }

        public enum PopTaxLevel
        {
            VeryLow,
            Low,
            Mid,
            High,
            VeryHigh
        }

        public enum MilitaryLevel
        {
            VeryLow,
            Low,
            Mid,
            High,
            VeryHigh
        }

        public enum LaborLevel
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
            public int Value => (int)(baseValue * (100 + effects.Sum(x => x.value)) / 100);
            public IEnumerable<(string desc, double value)> effects { get; set; }
        }

        public class PopCountChange
        {
            public IEnumerable<(string desc, double value)> effects { get; set; }
        }
    }
}
