using System.Collections.Generic;
using System.Linq;

namespace HuangD.Interfaces
{
    public interface IChaotingGroup
    {
        IEnumerable<IOffice> mainOffices => all.Where(x => ((IChaotingOfficeDef)x.def).isMain);
        IEnumerable<IOffice> branchOffices => all.Where(x => !((IChaotingOfficeDef)x.def).isMain);


        public IEnumerable<IOffice> all { get; }
    }
}
