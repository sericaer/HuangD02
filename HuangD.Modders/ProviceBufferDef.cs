using HuangD.Interfaces;
using System;
using System.Collections.Generic;
namespace HuangD.Modders
{
    public class ProviceBufferDef : IProviceBufferDef
    {

        public string name { get; internal set; }
        public IEnumerable<IEffectDef> effects { get; internal set; }

        public Func<IProvince, IDate, bool> isStart { get; internal set; }
        public Func<IProvince, IDate, bool> isEnd { get; internal set; }

    }
}
