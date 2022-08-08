using LogicSimEngine.Interfaces;
using System.Collections.Generic;

namespace HuangD.Interfaces
{
    public interface IModder
    {
        IModDefs defs { get; }
    }

    public interface IModDefs
    {
        IPersonDef personDef { get; }
        ICountryDef countryDef { get; }
        IPopTaxLevelDef popTaxLevelDef { get; }
        IMilitaryLevelDef militaryLevelDef { get; }
        ILaborLevelDef laborLevelDef { get; }

        IEnumerable<IOfficeDef> officeDefs { get; }
        IEnumerable<IPartyDef> partyDefs { get; }
        IEnumerable<IProvinceDef> provinceDefs { get; }

        IEnumerable<IBufferDef> bufferDefs { get; }
    }

    public interface IMilitaryLevelDef
    {
        IEnumerable<Item> items { get; }

        class Item
        {
            public IProvince.MilitaryLevel level;
            public IEnumerable<IEffectDef> effectDefs;
        }
    }

    public interface ILaborLevelDef
    {
        IEnumerable<Item> items { get; }

        class Item
        {
            public IProvince.LaborLevel level;
            public IEnumerable<IEffectDef> effectDefs;
        }
    }

    public interface IPopTaxLevelDef 
    {
        IEnumerable<Item> items { get; }

        class Item
        {
            public IProvince.PopTaxLevel popTaxLevel;
            public IEnumerable<IEffectDef> effectDefs;
        }
    }

    public interface IProvinceDef
    {
        string name { get; }
        IOfficeDef master { get; }

        int popCount { get; }
    }

    public interface IPartyDef
    {
        string name { get; }
    }

    public interface IOfficeDef
    {
        string name { get; }

        RespType responsibility { get; }
        int? score { get; }

        public interface IResponsibility
        {

        }

        public enum RespType
        {
            Empty,
            HuangHou,
            Gui,
            Fei,
            Bin,
        }
    }

    public interface IChaotingOfficeDef : IOfficeDef
    {
        bool isMain { get; }
        int power { get; }
    }

    public interface IHougongOfficeDef : IOfficeDef
    {
        int maxCount { get; }
    }

    public interface IPersonDef
    {
        string[] familyNames { get; }
        string[] givenNames { get; }

    }
}
