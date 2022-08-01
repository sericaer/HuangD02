using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.Interfaces
{
    public interface IProvince
    {
        string name { get; }
        IOffice masterOffice { get; }
        int popCount { get; }
        IMoneyMgr.TaxItem popTax { get; }

        PopTaxLevel popTaxLevel { get; set; }

        public enum PopTaxLevel
        {
            VeryLow,
            Low,
            Mid,
            High,
            VeryHigh
        }
    }
}
