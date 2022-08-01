using HuangD.Entities.Offices;
using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.Entities
{
    public class Province : IProvince
    {
        public static Func<IProvince, IMoneyMgr.TaxItem> funcGetCurrPopTax { get; set; }

        public string name => def.name;

        public IOffice masterOffice { get; }

        public IMoneyMgr.TaxItem popTax => funcGetCurrPopTax(this);

        public int popCount { get; }

        public IProvince.PopTaxLevel popTaxLevel { get; set; }

        private IProvinceDef def;

        public Province(IProvinceDef def)
        {
            this.def = def;
            this.masterOffice = new Office(def.master);
            this.popCount = def.popCount;
            this.popTaxLevel = IProvince.PopTaxLevel.Mid;
        }
    }
}
