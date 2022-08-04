using HuangD.Interfaces;
using LogicSimEngine.Interfaces;
using System;
using System.Collections.Generic;
namespace HuangD.Modders
{
    public class ProviceBufferDef : IProviceBufferDef
    {

        public string name { get; internal set; }
        public IEnumerable<IEffectDef> effects { get; internal set; }

        public Func<IContext, bool> isStart { get; internal set; }
        public Func<IContext, bool> isEnd { get; internal set; }

        public int startRandom { get; internal set; }

        public int endRandom { get; internal set; }

        public IEventDef endEvent { get; internal set; }

        public IEventDef startEvent { get; internal set; }
    }
}
