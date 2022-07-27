using HuangD.Interfaces;
using System;
using System.Linq;
namespace HuangD.Modders
{
    public partial class Modder
    {
        public static Modder Default = new Modder()
        {
            familyNames = Enumerable.Range(0, 100).Select(x => $"[F{x}]").ToArray(),
            givenNames = Enumerable.Range(0, 100).Select(x => $"[G{x}]").ToArray(),

            defs = new ModDefs()
            {
                officeDefs = new IOfficeDef[]
                {
                    new OfficeDef()
                    {
                        name = "chengxiang",
                        responsibility = new ChengXiangReps()
                    },
                    new OfficeDef()
                    {
                        name = "taiwei",
                        responsibility = new TaiweiReps()
                    },
                    new OfficeDef()
                    {
                        name = "yushi",
                        responsibility = new YushiReps()
                    },
                    new OfficeDef()
                    {
                        name = "huanghou",
                        responsibility = new HuangHouReps()
                    },
                    new OfficeDef()
                    {
                        name = "fei",
                        responsibility = new FeiReps()
                    },
                    new OfficeDef()
                    {
                        name = "bin",
                        responsibility = new BinReps()
                    },
                }
            }
        };
    }
}
