using HuangD.Interfaces;
using System;

namespace HuangD.Modders
{
    public partial class Modder : IModder
    {
        public IModDefs defs { get; private set; }
    }
}
