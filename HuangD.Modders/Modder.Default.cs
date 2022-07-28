using HuangD.Interfaces;
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

                officeDefs = new IOfficeDef[]
                {
                    new ChaotingOfficeDef()
                    {
                        name = "chengxiang",
                        isMain = true,
                    },
                    new ChaotingOfficeDef()
                    {
                        name = "taiwei",
                        isMain = true,
                    },
                    new ChaotingOfficeDef()
                    {
                        name = "yushi",
                        isMain = true,
                    },
                    new ChaotingOfficeDef()
                    {
                        name = "taichang",
                        isMain = false,
                    },
                    new ChaotingOfficeDef()
                    {
                        name = "shaofu",
                        isMain = false,
                    },
                    new ChaotingOfficeDef()
                    {
                        name = "tingwei",
                        isMain = false,
                    },
                    new ChaotingOfficeDef()
                    {
                        name = "tingwei",
                        isMain = false,
                    },
                    new ChaotingOfficeDef()
                    {
                        name = "tingwei",
                        isMain = false,
                    },
                    new ChaotingOfficeDef()
                    {
                        name = "tingwei",
                        isMain = false,
                    },
                    new ChaotingOfficeDef()
                    {
                        name = "tingwei",
                        isMain = false,
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
                }
            }
        };
    }
}
