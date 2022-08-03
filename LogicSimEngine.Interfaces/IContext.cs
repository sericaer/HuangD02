using System;
using System.Collections.Generic;

namespace LogicSimEngine.Interfaces
{
    public interface IContext
    {
        object this[string key] { get; }

        IDictionary<string, Func<object>> ext { get; set; }
    }

}
