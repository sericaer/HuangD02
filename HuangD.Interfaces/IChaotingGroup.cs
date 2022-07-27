using System.Collections.Generic;

namespace HuangD.Interfaces
{
    public interface IChaotingGroup
    {
        IEnumerable<IOffice> mainOffices { get; }
        IEnumerable<IOffice> branchOffices { get; }
    }
}
