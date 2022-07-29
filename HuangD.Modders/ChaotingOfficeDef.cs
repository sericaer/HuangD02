using HuangD.Interfaces;

namespace HuangD.Modders
{
    internal class ChaotingOfficeDef : IChaotingOfficeDef
    {
        public string name { get; internal set; }

        public IOfficeDef.RespType responsibility { get; internal set; }

        public bool isMain { get; internal set; }

        public int power { get; internal set; }

        public int? score => 5;
    }

    internal class HougongOfficeDef : IHougongOfficeDef
    {
        public string name { get; internal set; }

        public IOfficeDef.RespType responsibility { get; internal set; }

        public int maxCount { get; internal set; }

        public int? score => null;
    }
}