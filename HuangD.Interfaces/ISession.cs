using System;

namespace HuangD.Interfaces
{
    public interface ISession
    {
        public IPerson emperor { get; }
        public IDate date { get; }
        string yearName { get; }

        void OnTimeElapse();
    }
}
