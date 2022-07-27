using HuangD.Entities.Offices;
using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Sessions
{
    internal class HougongGroup : IHouGongGroup
    {
        public IEnumerable<IOffice> hous => _hous;

        public IEnumerable<IOffice> guis => _guis;

        public IEnumerable<IOffice> feis => _feis;

        public IEnumerable<IOffice> bins => _bins;

        private List<IOffice> _hous = new List<IOffice>();
        private List<IOffice> _guis = new List<IOffice>();
        private List<IOffice> _feis = new List<IOffice>();
        private List<IOffice> _bins = new List<IOffice>();

        public void AddHou()
        {
            _hous.Add(new HuangHou());
        }

        public void AddGui()
        {
            _guis.Add(new GuiFei());
        }

        public void AddFei()
        {
            _feis.Add(new Fei());
        }

        public void AddBin()
        {
            _bins.Add(new Bin());
        }
    }
}