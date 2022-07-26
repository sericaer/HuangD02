using HuangD.Interfaces;
using System;

namespace HuangD.Sessions
{
    public partial class Session : ISession
    {
        public IPerson emperor { get; private set; }

        public IDate date { get; private set; }

        public string yearName { get; private set; }

        public void OnTimeElapse()
        {
            date.day++;
        }
    }
}
