using System.Collections.Generic;

namespace HuangD.Interfaces
{
    public interface IHouGongGroup
    {
        IEnumerable<IOffice> hous { get; }
        IEnumerable<IOffice> guis { get; }
        IEnumerable<IOffice> feis { get; }
        IEnumerable<IOffice> bins { get; }

        void AddHou();
        void AddGui();
        void AddFei();
        void AddBin();

    }
}