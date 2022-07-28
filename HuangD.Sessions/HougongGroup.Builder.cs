using HuangD.Entities.Offices;
using HuangD.Interfaces;
using System;
using System.Collections.Generic;

namespace HuangD.Sessions
{
    internal partial class HougongGroup
    {
        public static class Builder
        {
            internal static HougongGroup Build(IEnumerable<IHougongOfficeDef> officeDefs)
            {
                var group = new HougongGroup();

                foreach(var def in officeDefs)
                {
                    for(int i =0; i< def.maxCount; i++)
                    {
                        group._all.Add(new Office(def));
                    }
                }

                return group;
            }
        }
    }
}