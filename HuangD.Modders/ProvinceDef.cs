using HuangD.Interfaces;

namespace HuangD.Modders
{
    internal class ProvinceDef : IProvinceDef
    {
        public string name { get; internal set; }

        public IOfficeDef master { get; internal set; }
    }
}