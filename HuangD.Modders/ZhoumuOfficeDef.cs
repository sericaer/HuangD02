using HuangD.Interfaces;

namespace HuangD.Modders
{
    internal class ZhoumuOfficeDef : IOfficeDef
    {
        public string name { get; internal set; }

        public IOfficeDef.RespType responsibility => throw new System.NotImplementedException();

        public int? score => 3;
    }
}