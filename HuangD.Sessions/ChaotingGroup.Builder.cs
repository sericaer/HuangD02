using HuangD.Entities.Offices;
using HuangD.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Sessions
{
    partial class ChaotingGroup
    {
        internal class Builder
        {
            internal static ChaotingGroup Build(IEnumerable<IChaotingOfficeDef> officeDefs)
            {
                var group = new ChaotingGroup();

                foreach(var def in officeDefs)
                {
                    group._all.Add(new Office(def));
                }

                return group;
            }
        }
    }
}
