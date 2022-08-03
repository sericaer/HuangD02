using LogicSimEngine.Interfaces;
using System;
using System.Collections.Generic;

namespace LogicSimEngine
{
    public class Context : IContext
    {
        public object this[string key]
        {
            get
            {
                Func<object> func;
                if (ext != null && ext.TryGetValue(key, out func))
                {
                    return func();
                }

                if(origin.TryGetValue(key, out func))
                {
                    return func();
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public Context(IDictionary<string, Func<object>> dictionary)
        {
            origin = dictionary;
        }

        public IDictionary<string, Func<object>> ext { get; set; }

        private IDictionary<string, Func<object>> origin { get; set; }
    }
}
