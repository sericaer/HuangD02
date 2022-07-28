using HuangD.Interfaces;
using System;
using System.Collections.Generic;

namespace HuangD.Entities
{
    public partial class Person
    {
        public static Func<(string familyName, string givenName)> funcGenNames;

        private Person()
        {
        }

        public static class Builder
        {
            public static IPerson Build()
            {
                var names = funcGenNames();

                var person = new Person();
                person.familyName = names.familyName;
                person.givenName = names.givenName;

                return person;
            }
        }
    }
}
