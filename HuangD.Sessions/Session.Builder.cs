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

                session.yearName = initData.country.yearName;
                session.emperor = new Person(initData.emperor);
                session.date = new Date();

                return session;
            }
        }
    }
}
