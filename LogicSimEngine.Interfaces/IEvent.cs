using System;

namespace LogicSimEngine.Interfaces
{
    public interface IEvent
    {
        string title { get; }

        Action OnExit { get; }
    }
}
