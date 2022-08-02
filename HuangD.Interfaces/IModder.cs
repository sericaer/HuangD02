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
        IEnumerable<IOfficeDef> officeDefs { get; }
        IEnumerable<IPartyDef> partyDefs { get; }
        IEnumerable<IProvinceDef> provinceDefs { get; }

        IEnumerable<IBufferDef> bufferDefs { get; }
    }

    public interface IPopTaxLevelDef 
    {
        IEnumerable<TaxLevelEffectGroup> taxLevelEffectGroups { get; }

        class TaxLevelEffectGroup
        {
            public IProvince.PopTaxLevel popTaxLevel;
            public IEnumerable<IEffectDef> effectDefs;
        }

        Dictionary<IProvince.PopTaxLevel, int> dictLevelPopTaxEffect { get; }
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
