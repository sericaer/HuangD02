using HuangD.Entities.Offices;
using HuangD.Interfaces;
using LogicSimEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.Entities
{
    public class Province : IProvince
    {
        public string name => def.name;

        public IOffice masterOffice { get; }
        public int popCount { get; set; }
        public IProvince.PopTaxLevel popTaxLevel { get; set; }
        public IProvince.MilitaryLevel militaryLevel { get; set; }
        public IProvince.LaborLevel laborLevel { get; set; }

        public IProvince.LiveliHood livelihood { get; }

        public List<IBuffer> buffers { get; }

        public IMoneyMgr.TaxItem popTax { get; }
        public IMilitaryMgr.Item military { get; }
        public ILaborMgr.Item labor { get; }

        public IDictionary<string, Func<object>> context { get; private set; }
        public IProvince.PopCountChange popCountChange { get; }

        private IProvinceDef def;

        public Province(IProvinceDef def)
        {
            this.def = def;

            this.masterOffice = new Office(def.master);
            this.popCount = def.popCount;
            this.popTaxLevel = IProvince.PopTaxLevel.Mid;
            this.militaryLevel = IProvince.MilitaryLevel.Mid;
            this.laborLevel = IProvince.LaborLevel.Mid;
            this.buffers = new List<IBuffer>();
            this.livelihood = new IProvince.LiveliHood();
            this.popCountChange = new IProvince.PopCountChange();
            this.military = new IMilitaryMgr.Item();
            this.popTax = new IMoneyMgr.TaxItem();
            this.labor = new ILaborMgr.Item();

            this.context = new Dictionary<string, Func<object>>()
            {
                { "province_livelihood", ()=>livelihood.Value }
            };
        }
    }
}
