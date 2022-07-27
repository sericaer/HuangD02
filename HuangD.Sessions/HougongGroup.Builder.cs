using HuangD.Interfaces;
using System;

namespace HuangD.Sessions
{
    internal partial class HougongGroup
    {
        public static class Builder
        {
            internal static HougongGroup Build()
            {
                var group = new HougongGroup();
                group.AddHou();

                for (int i = 0; i < 2; i++)
                {
                    group.AddGui();
                }

                for (int i = 0; i < 3; i++)
                {
                    group.AddFei();
                }

                for (int i = 0; i < 7; i++)
                {
                    group.AddBin();
                }

                return group;
            }
        }
    }
}