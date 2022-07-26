using HuangD.Interfaces;
using System;

namespace HuangD.Modders
{
    public partial class Modder : IModder
    {
        public string[] familyNames { get; private set; }

        public string[] givenNames { get; private set; }
    }
}
