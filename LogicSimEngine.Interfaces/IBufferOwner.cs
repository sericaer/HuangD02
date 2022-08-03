using System;
using System.Collections.Generic;

namespace LogicSimEngine.Interfaces
{
    public interface IBufferOwner
    {
        IDictionary<string, Func<object>> context { get; }
        List<IBuffer> buffers { get; }
    }

}
