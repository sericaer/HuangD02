using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.CustomInits
{
    public partial class CustomInit
    {
        public static CustomInit Default = new CustomInit()
        {
            seed = "DEFAULT",
            money = 10000,

            emperor = new EmperorInit()
            {
                familyName = "F1",
                givenName = "G1"
            },
            country = new CountryInit()
            {
                countryName = "C1",
                yearName = "Y1"
            }
        };
    }
}
