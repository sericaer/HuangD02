using HuangD.Interfaces;
using System;

namespace HuangD.Sessions
{
    public partial class Session : ISession
    {
        public IPerson emperor { get; private set; }
    }
}
