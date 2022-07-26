using HuangD.Interfaces;

namespace HuangD.CustomInits
{
    public class EmperorInit : IEmperorInit
    {
        public string familyName { get; set; }

        public string givenName  { get; set; }
    }

    public class CountryInit : ICounrtyInit
    {
        public string countryName { get; set; }

        public string yearName { get; set; }
    }
}
