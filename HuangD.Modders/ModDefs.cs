using HuangD.Interfaces;
using System.Collections.Generic;

namespace HuangD.Modders
{
    class ModDefs : IModDefs
    {
        public IEnumerable<IOfficeDef> officeDefs { get; internal set; }
    }
}