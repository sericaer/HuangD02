using HuangD.Interfaces;

namespace HuangD.Modders
{
    internal class OfficeDef : IOfficeDef
    {
        public string name { get; internal set; }

        public IOffice.IResponsibility responsibility { get; internal set; }
    }
}