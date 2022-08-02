using HuangD.Interfaces;
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
                        dictLevelEffect = new Dictionary<IProvince.PopTaxLevel, int>()
                        {
                            { IProvince.PopTaxLevel.VeryLow, -60 },
                            { IProvince.PopTaxLevel.Low, -30 },
                            { IProvince.PopTaxLevel.Mid, 0 },
                            { IProvince.PopTaxLevel.High, 30 },
                            { IProvince.PopTaxLevel.VeryHigh, 60 },
                        }
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
                            name = "MSDB",
                            effects = new IEffectDef[]
                            {
                                new PopTaxEffectDef()
                                {
                                    Value = -50
                                }
                            },
                            isStart = (province, date) =>
                            {
                                return date.day == 30 && province.popTaxLevel > IProvince.PopTaxLevel.Mid;
                            },
                            isEnd = (province, date) =>
                            {
                                return province.popTaxLevel < IProvince.PopTaxLevel.Mid;
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
