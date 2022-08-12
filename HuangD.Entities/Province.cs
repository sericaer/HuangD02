using HuangD.Entities.Offices;
using HuangD.Interfaces;
using LogicSimEngine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IProvince.ILiveliHood livelihood { get; }

        public List<IBuffer> buffers { get; }

        public IMoneyMgr.ITaxItem popTax { get; }
        public IMilitaryMgr.IItem military { get; }
        public ILaborMgr.IItem labor { get; }

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
            this.livelihood = new LiveliHood();
            this.popCountChange = new IProvince.PopCountChange();
            this.military = new MilitaryItem();
            this.popTax = new TaxItem();
            this.labor = new LaborItem();

            this.context = new Dictionary<string, Func<object>>()
            {
                { "province_livelihood", ()=>livelihood.Value }
            };
        }
    }

    public class LiveliHood : IProvince.ILiveliHood
    {
        public int baseValue => GetBaseValue();
        public int Value => (int)(baseValue * (100 + effects.Sum(x => x.value)) / 100);
        public IEnumerable<(string desc, double value)> effects => GetEffect();

        public Func<int> GetBaseValue;
        public Func<IEnumerable<(string desc, double value)>> GetEffect;
    }

    public class MilitaryItem : IMilitaryMgr.IItem
    {
        public int baseValue => GetBaseValue();
        public int currValue { get; set; }
        public int maxValue => (int)(baseValue * Math.Max(0, (100 + effects.Sum(x => x.value))) / 100);
        public IEnumerable<(string desc, double value)> effects => GetEffect();


        public Func<int> GetBaseValue;
        public Func<IEnumerable<(string desc, double value)>> GetEffect;
    }

    public class LaborItem : ILaborMgr.IItem
    {
        public int baseValue => GetBaseValue();
        public int currValue { get; set; }
        public int maxValue => (int)(baseValue * Math.Max(0, (100 + effects.Sum(x => x.value))) / 100);
        public IEnumerable<(string desc, double value)> effects => GetEffect();

        public Func<int> GetBaseValue;
        public Func<IEnumerable<(string desc, double value)>> GetEffect;
    }

    public class TaxItem : IMoneyMgr.ITaxItem
    {
        public int baseValue => GetBaseValue();
        public int Value => (int)(baseValue * Math.Max(0, (100 + effects.Sum(x => x.value))) / 100);
        public IEnumerable<(string desc, double value)> effects => GetEffect();

        public Func<int> GetBaseValue;
        public Func<IEnumerable<(string desc, double value)>> GetEffect;
    }
}
