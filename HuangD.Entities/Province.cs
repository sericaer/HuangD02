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

        public IOffice masterOffice { get; }
        public int popCount { get; }
        public IProvince.PopTaxLevel popTaxLevel { get; set; }
        public List<IBuffer> buffers { get; }

        public string name => def.name;

        public IMoneyMgr.TaxItem popTax => funcGetCurrPopTax(this);


        private IProvinceDef def;

        public Province(IProvinceDef def)
        {
            this.def = def;

            this.masterOffice = new Office(def.master);
            this.popCount = def.popCount;
            this.popTaxLevel = IProvince.PopTaxLevel.Mid;
            this.buffers = new List<IBuffer>();
        }
    }

    public class Buffer : IBuffer
    {
        public IBufferDef def { get; }

        public (int year, int month, int day) startDate { get; }

        public Buffer(IBufferDef def, IDate start)
        {
            this.def = def;
            this.startDate = (start.year, startDate.month, startDate.day);
        }
    }
}
