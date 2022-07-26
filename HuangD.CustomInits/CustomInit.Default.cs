using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.CustomInits
{
    public partial class CustomInit
    {
        public static CustomInit Default = new CustomInit()
        {
            emperor = new EmperorInit()
            {
                familyName = "F1",
                givenName = "G1"
            }
        };
    }
}
