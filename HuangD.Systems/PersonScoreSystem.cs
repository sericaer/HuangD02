using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class PersonScoreSystem
    {
        private Dictionary<IPerson, List<IPerson.ScoreItem>> scoreTable;

        public PersonScoreSystem()
        {
            scoreTable = new Dictionary<IPerson, List<IPerson.ScoreItem>>();
        }

        public IEnumerable<IPerson.ScoreItem> GetScoreItems(IPerson person)
        {
            List<IPerson.ScoreItem> items;

            if (!scoreTable.TryGetValue(person, out items))
            {
                return null;
            }

            return items;
        }

        public void Process(IEnumerable<IPerson> persons, IDate date)
        {
            if(date.month == 12 && date.day == 30)
            {
                foreach (var person in persons.Where(x => x.currOffice != null && x.currOffice.score != null))
                {
                    List<IPerson.ScoreItem> scoreItems;

                    if(!scoreTable.TryGetValue(person, out scoreItems))
                    {
                        scoreItems = new List<IPerson.ScoreItem>();
                        scoreTable.Add(person, scoreItems);
                    }

                    if(!scoreTable.ContainsKey(person))
                    {
                        scoreTable.Add(person, new List<IPerson.ScoreItem>());
                    }

                    scoreItems.Add(new IPerson.ScoreItem(date, "YEAR SCORE", person.currOffice.score.Value));
                }
            }
        }
    }
}
