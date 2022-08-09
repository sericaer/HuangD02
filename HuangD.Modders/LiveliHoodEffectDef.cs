using HuangD.Interfaces;

namespace HuangD.Modders
{
    internal class LiveliHoodEffectDef : ILiveliHoodEffectDef
    {
        public double Value { get; set; }

        public string name => "民生";
    }
}