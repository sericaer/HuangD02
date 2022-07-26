using HuangD.Interfaces;
using System;

namespace HuangD.CustomInits
{
    public partial class CustomInit : ICustomInit
    {
        public IEmperorInit emperor { get; set; }

        public ICounrtyInit country { get; set; }
    }
}
