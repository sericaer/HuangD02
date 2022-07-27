using HuangD.Interfaces;
using System;
using System.Collections.Generic;

namespace HuangD.Entities
{
    public class Person : IPerson
    {
        public static Func<IPerson, IEnumerable<IPerson2Office>> funcGetToOfficeRelations;

        public string familyName { get; }
        public string givenName { get; }

        public IEnumerable<IPerson2Office> toOfficeRelations => funcGetToOfficeRelations(this);

        public Person((string family, string given) name)
        {
            familyName = name.family;
            givenName = name.given;
        }
    }
}
