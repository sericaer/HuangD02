using HuangD.Interfaces;
using System;

namespace HuangD.Entities
{
    public class Person : IPerson
    {
        public string familyName { get; }
        public string givenName { get; }

        public Person(IEmperorInit emperor)
        {
            familyName = emperor.familyName;
            givenName = emperor.givenName;
        }
    }
}
