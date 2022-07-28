using HuangD.Entities.Offices;
using HuangD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Sessions
{
    internal partial class HougongGroup : IHouGongGroup
    {
        public IEnumerable<IOffice> hous => _all.Where(x => x.def.responsibility == IOfficeDef.RespType.HuangHou);

        public IEnumerable<IOffice> guis => _all.Where(x => x.def.responsibility == IOfficeDef.RespType.Gui);

        public IEnumerable<IOffice> feis => _all.Where(x => x.def.responsibility == IOfficeDef.RespType.Fei);

        public IEnumerable<IOffice> bins => _all.Where(x => x.def.responsibility == IOfficeDef.RespType.Bin);

        private List<IOffice> _all = new List<IOffice>();

        public IEnumerator<IOffice> GetEnumerator()
        {
            return _all.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _all.GetEnumerator();
        }
    }
}