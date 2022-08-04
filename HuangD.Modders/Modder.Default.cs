using HuangD.Interfaces;
using LogicSimEngine.Interfaces;
using System.Collections.Generic;
using System.Linq;
namespace HuangD.Modders
{
    public partial class Modder
    {
        public static Modder Default;
        
        static Modder()
        {
            Default = new Modder()
            {
                defs = new ModDefs()
                {
                    personDef = new PersonDef()
                    {
                        familyNames = Enumerable.Range(0, 100).Select(x => $"[F{x}]").ToArray(),
                        givenNames = Enumerable.Range(0, 100).Select(x => $"[G{x}]").ToArray(),
                    },

                    countryDef = new CountryDef()
                    {
                        countryNames = Enumerable.Range(0, 100).Select(x => $"[COUNTRY{x}]").ToArray(),
                        yearNames = Enumerable.Range(0, 100).Select(x => $"[YEAR{x}]").ToArray(),
                    },

                    popTaxLevelDef = new PopTaxLevelDef()
                    {
                        taxLevelEffectGroups = new IPopTaxLevelDef.TaxLevelEffectGroup[]
                        {
                            new IPopTaxLevelDef.TaxLevelEffectGroup()
                            {
                                popTaxLevel = IProvince.PopTaxLevel.VeryLow,
                                effectDefs = new IEffectDef[]
                                {
                                    new PopTaxEffectDef() { Value = -60 },
                                    new LiveliHoodEffectDef() { Value = 0 }
                                }
                            },
                            new IPopTaxLevelDef.TaxLevelEffectGroup()
                            {
                                popTaxLevel = IProvince.PopTaxLevel.Low,
                                effectDefs = new IEffectDef[]
                                {
                                    new PopTaxEffectDef() { Value = -30 },
                                    new LiveliHoodEffectDef() { Value = -10 }
                                }
                            },
                            new IPopTaxLevelDef.TaxLevelEffectGroup()
                            {
                                popTaxLevel = IProvince.PopTaxLevel.Mid,
                                effectDefs = new IEffectDef[]
                                {
                                    new PopTaxEffectDef() { Value = 0 },
                                    new LiveliHoodEffectDef() { Value = -20 }
                                }
                            },
                            new IPopTaxLevelDef.TaxLevelEffectGroup()
                            {
                                popTaxLevel = IProvince.PopTaxLevel.High,
                                effectDefs = new IEffectDef[]
                                {
                                    new PopTaxEffectDef() { Value = 30 },
                                    new LiveliHoodEffectDef() { Value = -30 }
                                }
                            },
                            new IPopTaxLevelDef.TaxLevelEffectGroup()
                            {
                                popTaxLevel = IProvince.PopTaxLevel.VeryHigh,
                                effectDefs = new IEffectDef[]
                                {
                                    new PopTaxEffectDef() { Value = 60 },
                                    new LiveliHoodEffectDef() { Value = -40 }
                                }
                            },
                        },
                    },

                    partyDefs = new IPartyDef[]
                    {
                        new PartyDef()
                        {
                            name = "P0"
                        },
                        new PartyDef()
                        {
                            name = "P1"
                        },
                        new PartyDef()
                        {
                            name = "P2"
                        },
                        new PartyDef()
                        {
                            name = "P3"
                        },
                    },

                    bufferDefs = new IBufferDef[]
                    {
                        new ProviceBufferDef()
                        {
                            name = "民生凋敝",
                            effects = new IEffectDef[]
                            {
                                new PopTaxEffectDef()
                                {
                                    Value = -50
                                }
                            },
                            isStart = (context) =>
                            {
                                return (int)context["day"] == 30 && (int)context["province_livelihood"] <= 60;
                            },
                            isEnd = (context) =>
                            {
                                return  (int)context["day"] == 30 && (int)context["province_livelihood"] > 70;
                            },
                            startRandom = 30,
                            endRandom = 9,
                            startEvent = new EventDef
                            {
                                title = "EVET_BUFFER_START"
                            },
                            endEvent = new EventDef
                            {
                                title = "EVET_BUFFER_END"
                            }
                        }
                    },

                    officeDefs = new IOfficeDef[]
                    {
                        new ChaotingOfficeDef()
                        {
                            name = "chengxiang",
                            isMain = true,
                            power = 30,
                        },
                        new ChaotingOfficeDef()
                        {
                            name = "taiwei",
                            isMain = true,
                            power = 30,
                        },
                        new ChaotingOfficeDef()
                        {
                            name = "yushi",
                            isMain = true,
                            power = 30,
                        },
                        new ChaotingOfficeDef()
                        {
                            name = "taichang",
                            isMain = false,
                            power = 10,
                        },
                        new ChaotingOfficeDef()
                        {
                            name = "shaofu",
                            isMain = false,
                            power = 10,
                        },
                        new ChaotingOfficeDef()
                        {
                            name = "tingwei",
                            isMain = false,
                            power = 10,
                        },
                        new ChaotingOfficeDef()
                        {
                            name = "tingwei",
                            isMain = false,
                            power = 10,
                        },
                        new ChaotingOfficeDef()
                        {
                            name = "tingwei",
                            isMain = false,
                            power = 10,
                        },
                        new ChaotingOfficeDef()
                        {
                            name = "tingwei",
                            isMain = false,
                            power = 10,
                        },
                        new ChaotingOfficeDef()
                        {
                            name = "tingwei",
                            isMain = false,
                            power = 10,
                        },
                        new HougongOfficeDef()
                        {
                            name = "Huanghou",
                            maxCount = 1,
                            responsibility = IOfficeDef.RespType.HuangHou
                        },
                        new HougongOfficeDef()
                        {
                            name = "Gui",
                            maxCount = 2,
                            responsibility = IOfficeDef.RespType.Gui
                        },
                        new HougongOfficeDef()
                        {
                            name = "Fei",
                            maxCount = 3,
                            responsibility = IOfficeDef.RespType.Fei
                        },
                        new HougongOfficeDef()
                        {
                            name = "Bin",
                            maxCount = 10,
                            responsibility = IOfficeDef.RespType.Bin
                        },
                        new ZhoumuOfficeDef()
                        {
                            name = "Zhoumu"
                        }
                    },

                    provinceDefs = new IProvinceDef[]
                    {
                        new ProvinceDef()
                        {
                            name = "PROV0",
                            popCount = 100
                        },
                        new ProvinceDef()
                        {
                            name = "PROV1",
                            popCount = 111
                        },
                        new ProvinceDef()
                        {
                            name = "PROV2",
                            popCount = 122
                        },
                        new ProvinceDef()
                        {
                            name = "PROV3",
                            popCount = 133
                        },
                        new ProvinceDef()
                        {
                            name = "PROV4",
                            popCount = 144
                        },
                        new ProvinceDef()
                        {
                            name = "PROV5",
                            popCount = 155
                        },
                        new ProvinceDef()
                        {
                            name = "PROV6",
                            popCount = 16
                        },
                        new ProvinceDef()
                        {
                            name = "PROV7",
                            popCount = 17
                        },
                        new ProvinceDef()
                        {
                            name = "PROV8",
                            popCount = 18
                        }
                    }
                }
            };

            foreach(var def in Default.defs.provinceDefs.OfType<ProvinceDef>())
            {
                def.master = Default.defs.officeDefs.SingleOrDefault(x => x is ZhoumuOfficeDef);
            }
        }
        
    }

    internal class PopTaxEffectDef : IPopTaxEffectDef
    {
        public string name { get; } = "人口税";
        public int Value { get; internal set; }
    }
}
