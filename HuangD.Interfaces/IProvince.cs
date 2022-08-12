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
        IMoneyMgr.ITaxItem popTax { get; }
        IMilitaryMgr.IItem military { get; }
        ILaborMgr.IItem labor { get; }

        ILiveliHood livelihood { get; }

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

        public interface ILiveliHood
        {
            public int baseValue { get; }
            public int Value { get; }
            public IEnumerable<(string desc, double value)> effects { get; }
        }

        public class PopCountChange
        {
            public IEnumerable<(string desc, double value)> effects { get; set; }
        }
    }
}
