using HuangD.Entities;
using HuangD.Interfaces;
using HuangD.Relations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Sessions
{
    public partial class Session
    {
        public static class Builder
        {
            public static Session Build(ICustomInit initData, IModDefs modDefs)
            {
                var session = new Session(modDefs);

                session.yearName = initData.country.yearName;
                session.emperor = new Person((initData.emperor.familyName, initData.emperor.givenName));
                session.date = new Date();

                session.chaoting = ChaotingGroup.Builder.Build(modDefs.officeDefs.OfType<IChaotingOfficeDef>());
                session.hougong = HougongGroup.Builder.Build();

                session.persons = new List<IPerson>();
                for (int i=0; i<100; i++)
                {
                    session.persons.Add(Person.Builder.Build());
                }


                session.relationMgr = RelationMgr.Builder.Build(session.persons, session.chaoting);


                return session;
            }
        }
    }

    //static class PersonNameGenerator
    //{
    //    public static PersonDef def;
    //    internal static (string family, string given) Gen()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
