using HuangD.Interfaces;

namespace HuangD.Modders
{
    internal class ChaotingOfficeDef : IChaotingOfficeDef
    {
        public string name { get; internal set; }

        public IOfficeDef.IResponsibility responsibility { get; internal set; }

        public bool isMain { get; internal set; }
    }
}