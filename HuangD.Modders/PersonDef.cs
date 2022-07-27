using HuangD.Interfaces;

namespace HuangD.Modders
{
    internal class PersonDef : IPersonDef
    {
        public string[] familyNames { get; internal set; }

        public string[] givenNames { get; internal set; }
    }
}