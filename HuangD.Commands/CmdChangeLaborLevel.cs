using HuangD.Interfaces;
using LogicSimEngine.Interfaces;

namespace HuangD.Commands
{
    public class CmdChangeLaborLevel : ICommand
    {
        private IProvince province;
        private ILaborLevelDef.Item levelItem;

        public CmdChangeLaborLevel(IProvince province, ILaborLevelDef.Item levelItem)
        {
            this.province = province;
            this.levelItem = levelItem;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            province.laborLevel = levelItem.level;
        }
    }
}
