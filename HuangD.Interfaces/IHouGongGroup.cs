using System.Collections.Generic;

namespace HuangD.Interfaces
{
    public interface IHouGongGroup : IEnumerable<IOffice>
    {
        IEnumerable<IOffice> hous { get; }
        IEnumerable<IOffice> guis { get; }
        IEnumerable<IOffice> feis { get; }
        IEnumerable<IOffice> bins { get; }
    }
}