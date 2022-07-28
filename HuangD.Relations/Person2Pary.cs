using HuangD.Interfaces;

namespace HuangD.Relations
{
    internal class Person2Pary : IPerson2Party
    {
        public IPerson person { get; private set; }

        public IParty party { get; private set; }

        public Person2Pary(IPerson person, IParty party)
        {
            this.person = person;
            this.party = party;
        }
    }
}