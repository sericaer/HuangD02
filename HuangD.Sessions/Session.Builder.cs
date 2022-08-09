using HuangD.Entities;
using HuangD.Interfaces;
using HuangD.Relations;
using HuangD.Systems;
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
                session.engine = new LogicSimEngine.Engine(initData.seed);

                session.yearName = initData.country.yearName;
                session.emperor = new Person((initData.emperor.familyName, initData.emperor.givenName));
                session.date = new Date();

                session.chaoting = ChaotingGroup.Builder.Build(modDefs.officeDefs.OfType<IChaotingOfficeDef>());
                session.hougong = HougongGroup.Builder.Build(modDefs.officeDefs.OfType<IHougongOfficeDef>());

                session.moneyMgr = new MoneyMgr(initData.money);
                session.militaryMgr = new MilitaryMgr();
                session.laborMgr = new LaborMgr();

                session.popTaxSystem = new PopTaxSystem(modDefs.popTaxLevelDef);
                session.liveliHoodSystem = new LiveliHoodSystem(modDefs);
                session.popCountIncreaseSystem = new PopIncreaseSystem();
                session.militarySystem = new MilitarySystem(modDefs.militaryLevelDef);
                session.militarySpendSystem = new MilitarySpendSystem();
                session.laborSystem = new LaborSystem(modDefs.laborLevelDef);

                session.persons = new List<IPerson>();
                for (int i=0; i<100; i++)
                {
                    session.persons.Add(Person.Builder.Build());
                }

                session.parties = new List<IParty>();
                foreach(var def in modDefs.partyDefs)
                {
                    session.parties.Add(new Party(def));
                }

                session.provinces = new List<IProvince>();
                foreach (var def in modDefs.provinceDefs)
                {
                    session.provinces.Add(new Province(def));
                }

                session.relationMgr = RelationMgr.Builder.Build(session.persons, session.chaoting, session.hougong, session.parties, session.provinces);


                return session;
            }
        }
    }
}
