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
                var session = new Session();

                session.yearName = initData.country.yearName;
                session.emperor = new Person((initData.emperor.familyName, initData.emperor.givenName));
                session.date = new Date();
                session.relationMgr = new RelationMgr();

                session.persons = new List<IPerson>();
                session.chaoting = ChaotingGroup.Builder.Build(modDefs.officeDefs.OfType<IChaotingOfficeDef>());

                session.hougong = new HougongGroup();

                session.hougong.AddHou();

                for(int i=0; i<2; i++)
                {
                    session.hougong.AddGui();
                }

                for (int i = 0; i < 3; i++)
                {
                    session.hougong.AddFei();
                }

                for (int i = 0; i < 7; i++)
                {
                    session.hougong.AddBin();
                }

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
