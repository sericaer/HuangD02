using LogicSimEngine.Interfaces;
using System;

namespace LogicSimEngine
{
    public class Event : IEvent
    {
        public string title => def.title;

        private IEventDef def;
        private IContext context;

        public Event(IEventDef def, IContext context)
        {
            this.def = def;
            this.context = context;
        }

        public Action OnExit { get; internal set; }
    }
}