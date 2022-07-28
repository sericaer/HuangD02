using HuangD.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Relations
{
    internal class Person2Office : IPerson2Office
    {
        public IPerson person { get; private set; }

        public IOffice office { get; private set; }

        public bool isCurrent => history.Last().endDate == null;

        public IEnumerable<((int y, int m, int d)? startDate, (int y, int m, int d)? endDate)> history => _history;

        private List<((int y, int m, int d)? startDate, (int y, int m, int d)? endDate)> _history = new List<((int y, int m, int d)? startDate, (int y, int m, int d)? endDate)>();

        public Person2Office(IPerson person, IOffice office, (int y, int m, int d) date)
        {
            this.person = person;
            this.office = office;
            _history.Add((date, null));
        }

    }
}