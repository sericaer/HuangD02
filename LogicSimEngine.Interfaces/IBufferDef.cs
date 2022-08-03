using System;
using System.Collections.Generic;

namespace LogicSimEngine.Interfaces
{

    public interface IBufferDef
    {
        string name { get; }
        IEnumerable<IEffectDef> effects { get; }

        Func<IContext, bool> isStart { get; }
        Func<IContext, bool> isEnd { get; }

        int startRandom { get; }
        int endRandom { get; }
    }
}
