using HuangD.Interfaces;

namespace HuangD.Modders
{
    internal class LiveliHoodEffectDef : ILiveliHoodEffectDef
    {
        public int Value { get; set; }

        public string name => "LiveliHood";
    }
}