using HuangD.Interfaces;
using LogicSimEngine.Interfaces;
using System;

namespace HuangD.Commands
{
    public class CmdChangePopTaxLevel : ICommand
    {
        private IProvince province;
        private IPopTaxLevelDef.TaxLevelEffectGroup taxLevelItem;

        public CmdChangePopTaxLevel(IProvince province, IPopTaxLevelDef.TaxLevelEffectGroup taxLevelItem)
        {
            this.province = province;
            this.taxLevelItem = taxLevelItem;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            province.popTaxLevel = taxLevelItem.popTaxLevel;
        }
    }
}
