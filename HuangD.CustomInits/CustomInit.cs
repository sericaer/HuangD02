using HuangD.Interfaces;
using System;

namespace HuangD.CustomInits
{
    public partial class CustomInit : ICustomInit
    {
        public string seed { get; set; }

        public IEmperorInit emperor { get; set; }

        public ICounrtyInit country { get; set; }

        public int money => 200000;
    }
}
