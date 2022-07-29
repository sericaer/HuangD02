﻿using HuangD.Interfaces;
using System;
using System.Linq;
namespace HuangD.Modders
{
    public partial class Modder
    {
        public static Modder Default = new Modder()
        {
            defs = new ModDefs()
            {
                personDef = new PersonDef()
                {
                    familyNames = Enumerable.Range(0, 100).Select(x => $"[F{x}]").ToArray(),
                    givenNames = Enumerable.Range(0, 100).Select(x => $"[G{x}]").ToArray(),
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
                    }
                },

                provinceDefs = new IProvinceDef[]
                {
                    new ProvinceDef()
                    {
                        name = "PROV0"
                    },
                    new ProvinceDef()
                    {
                        name = "PROV1"
                    },
                    new ProvinceDef()
                    {
                        name = "PROV2"
                    },
                    new ProvinceDef()
                    {
                        name = "PROV3"
                    },
                    new ProvinceDef()
                    {
                        name = "PROV4"
                    },
                    new ProvinceDef()
                    {
                        name = "PROV5"
                    },
                    new ProvinceDef()
                    {
                        name = "PROV6"
                    },
                    new ProvinceDef()
                    {
                        name = "PROV7"
                    },
                    new ProvinceDef()
                    {
                        name = "PROV8"
                    },
                    new ProvinceDef()
                    {
                        name = "PROV9"
                    }
                }
            }
        };
    }
}
