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
                        items = new IPopTaxLevelDef.Item[]
                        {
                            new IPopTaxLevelDef.Item()
                            {
                                popTaxLevel = IProvince.PopTaxLevel.VeryLow,
                                effectDefs = new IEffectDef[]
                                {
                                    new PopTaxEffectDef() { Value = -50 },
                                    new LiveliHoodEffectDef() { Value = -5 }
                                }
                            },
                            new IPopTaxLevelDef.Item()
                            {
                                popTaxLevel = IProvince.PopTaxLevel.Low,
                                effectDefs = new IEffectDef[]
                                {
                                    new PopTaxEffectDef() { Value = -30 },
                                    new LiveliHoodEffectDef() { Value = -10 }
                                }
                            },
                            new IPopTaxLevelDef.Item()
                            {
                                popTaxLevel = IProvince.PopTaxLevel.Mid,
                                effectDefs = new IEffectDef[]
                                {
                                    new PopTaxEffectDef() { Value = 0 },
                                    new LiveliHoodEffectDef() { Value = -20 }
                                }
                            },
                            new IPopTaxLevelDef.Item()
                            {
                                popTaxLevel = IProvince.PopTaxLevel.High,
                                effectDefs = new IEffectDef[]
                                {
                                    new PopTaxEffectDef() { Value = 30 },
                                    new LiveliHoodEffectDef() { Value = -30 }
                                }
                            },
                            new IPopTaxLevelDef.Item()
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

                    militaryLevelDef = new MilitaryLevelDef()
                    {
                        items = new IMilitaryLevelDef.Item[]
                        {
                            new IMilitaryLevelDef.Item()
                            {
                                level = IProvince.MilitaryLevel.VeryLow,
                                effectDefs = new IEffectDef[]
                                {
                                    new MilitaryCountEffectDef() { Value = -50 },
                                    new LiveliHoodEffectDef() { Value = -5 }
                                }
                            },
                            new IMilitaryLevelDef.Item()
                            {
                                level = IProvince.MilitaryLevel.Low,
                                effectDefs = new IEffectDef[]
                                {
                                    new MilitaryCountEffectDef() { Value = -30 },
                                    new LiveliHoodEffectDef() { Value = -10 }
                                }
                            },
                            new IMilitaryLevelDef.Item()
                            {
                                level = IProvince.MilitaryLevel.Mid,
                                effectDefs = new IEffectDef[]
                                {
                                    new MilitaryCountEffectDef() { Value = 0 },
                                    new LiveliHoodEffectDef() { Value = -20 }
                                }
                            },
                            new IMilitaryLevelDef.Item()
                            {
                                level = IProvince.MilitaryLevel.High,
                                effectDefs = new IEffectDef[]
                                {
                                    new MilitaryCountEffectDef() { Value = 30 },
                                    new LiveliHoodEffectDef() { Value = -30 }
                                }
                            },
                            new IMilitaryLevelDef.Item()
                            {
                                level = IProvince.MilitaryLevel.VeryHigh,
                                effectDefs = new IEffectDef[]
                                {
                                    new MilitaryCountEffectDef() { Value = 60 },
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
                                    Value = -40
                                },
                                new PopIncreaseEffectDef()
                                {
                                    Value = -1.5
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
                            name = "冀州",
                            popCount = 10000
                        },
                        new ProvinceDef()
                        {
                            name = "豫州",
                            popCount = 10000
                        },
                        new ProvinceDef()
                        {
                            name = "徐州",
                            popCount = 6000
                        },
                        new ProvinceDef()
                        {
                            name = "雍州",
                            popCount = 6000
                        },
                        new ProvinceDef()
                        {
                            name = "荆州",
                            popCount = 8000
                        },
                        new ProvinceDef()
                        {
                            name = "扬州",
                            popCount = 4000
                        },
                        new ProvinceDef()
                        {
                            name = "并州",
                            popCount = 1000
                        },
                        new ProvinceDef()
                        {
                            name = "幽州",
                            popCount = 2000
                        },
                        new ProvinceDef()
                        {
                            name = "凉州",
                            popCount = 1200
                        },
                        new ProvinceDef()
                        {
                            name = "益州",
                            popCount = 8000
                        },
                        new ProvinceDef()
                        {
                            name = "青州",
                            popCount = 3000
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

    internal class PopIncreaseEffectDef : IPopIncreaseEffectDef
    {
        public string name { get; } = "人口增长";
        public double Value { get; internal set; }
    }

    internal class PopTaxEffectDef : IPopTaxEffectDef
    {
        public string name { get; } = "人口税";
        public double Value { get; internal set; }
    }

    internal class MilitaryCountEffectDef : IMilitaryCountEffectDef
    {
        public string name { get; } = "兵役数";
        public double Value { get; internal set; }
    }
}
