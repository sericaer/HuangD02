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
        };
    }
}
