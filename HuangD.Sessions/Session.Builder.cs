using HuangD.Entities;
using HuangD.Interfaces;

namespace HuangD.Sessions
{
    public partial class Session
    {
        public static class Builder
        {
            public static Session Build(ICustomInit initData)
            {
                var session = new Session();
                session.emperor = new Person(initData.emperor);

                return session;
            }
        }
    }
}
