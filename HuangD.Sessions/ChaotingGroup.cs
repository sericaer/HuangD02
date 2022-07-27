using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Sessions
{
    partial class ChaotingGroup : IChaotingGroup
    {
        public IEnumerable<IOffice> all => _all;

        private List<IOffice> _all = new List<IOffice>();
    }
}
