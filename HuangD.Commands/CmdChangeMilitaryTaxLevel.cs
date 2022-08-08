using HuangD.Interfaces;
using LogicSimEngine.Interfaces;

namespace HuangD.Commands
{
    public class CmdChangeMilitaryLevel : ICommand
    {
        private IProvince province;
        private IMilitaryLevelDef.Item levelItem;

        public CmdChangeMilitaryLevel(IProvince province, IMilitaryLevelDef.Item levelItem)
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
            province.militaryLevel = levelItem.level;
        }
    }
}
