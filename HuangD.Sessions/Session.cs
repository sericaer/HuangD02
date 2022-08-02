using HuangD.Entities;
using HuangD.Entities.Offices;
using HuangD.Interfaces;
using HuangD.Systems;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Sessions
{
    public partial class Session : ISession
    {
        public IPerson emperor { get; private set; }

        public IDate date { get; private set; }

        public string yearName { get; private set; }

        public IRelationMgr relationMgr { get; private set; }

        public IList<IPerson> persons { get; private set; }

        public IList<IParty> parties { get; private set; }
        public IChaotingGroup chaoting { get; private set; }

        public IHouGongGroup hougong { get; private set; }

        public IModDefs modDefs { get; private set; }

        public IList<IProvince> provinces { get; private set; }

        public IMoneyMgr moneyMgr { get; private set; }

        private PersonScoreSystem personScoreSystem = new PersonScoreSystem();
        private MoneyCollectSystem moneyCollectSystem = new MoneyCollectSystem();
        private ProvinceBufferSystem proviceBufferSystem;
        private PopTaxSystem popTaxSystem;

        private Random random;

        public Session(IModDefs modDefs)
        {
            random = new Random();

            Person.funcGetToOfficeRelations = (person) =>
            {
                return relationMgr.person2Offices.Where(x => x.person == person);
            };

            Person.funcGetToPartyRelations = (person) =>
            {
                return relationMgr.person2Parties.Where(x => x.person == person);
            };

            Person.funcGenNames = () =>
            {
                var familyNames = modDefs.personDef.familyNames;
                var givenNames = modDefs.personDef.givenNames;

                var familyNameIndex = -1;
                var givenNameIndex = -1;
                do
                {
                    familyNameIndex = random.Next(0, modDefs.personDef.familyNames.Length);
                    givenNameIndex = random.Next(0, modDefs.personDef.givenNames.Length);
                }
                while (persons.Any(x => x.familyName == familyNames[familyNameIndex] && x.givenName == givenNames[givenNameIndex]));

                return (familyNames[familyNameIndex], givenNames[givenNameIndex]);
            };

            Person.funcGetScoreItems = (person) =>
            {
                return personScoreSystem.GetScoreItems(person);
            };

            Office.funcGetToPersonRelations = (office) =>
            {
                return relationMgr.person2Offices.Where(x => x.office == office);
            };

            Party.funcGetToPersonRelations = (party) =>
            {
                return relationMgr.person2Parties.Where(x => x.party == party);
            };

            Province.funcGetCurrPopTax = (province) =>
            {
                return moneyMgr.tables[IMoneyMgr.CollectType.POPTAX][province]();
            };
        }

        public void OnTimeElapse()
        {
            date.day++;

            personScoreSystem.Process(persons, date);

            popTaxSystem.Process(moneyMgr, provinces, date);
            moneyCollectSystem.Process(moneyMgr, date);

            proviceBufferSystem.Process(provinces, date);

        }
    }


}
