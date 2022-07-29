using HuangD.Interfaces;

namespace HuangD.Modders
{
    internal class CountryDef : ICountryDef
    {
        public string[] countryNames { get; internal set; }

        public string[] yearNames { get; internal set; }
    }
}