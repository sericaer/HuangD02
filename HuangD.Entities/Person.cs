using HuangD.Interfaces;
using System;
using System.Collections.Generic;

namespace HuangD.Entities
{
    public partial class Person : IPerson
    {
        public static Func<IPerson, IEnumerable<IPerson2Office>> funcGetToOfficeRelations;

        public string familyName { get; private set; }
        public string givenName { get; private set; }

        public IEnumerable<IPerson2Office> toOfficeRelations => funcGetToOfficeRelations(this);

        public Person((string family, string given) name)
        {
            familyName = name.family;
            givenName = name.given;
        }
    }
}
