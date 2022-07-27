using System.Collections.Generic;

namespace HuangD.Interfaces
{
    public interface IModder
    {
        string[] familyNames { get; }
        string[] givenNames { get; }

        IModDefs defs { get; }
    }

    public interface IModDefs
    {
        IEnumerable<IOfficeDef> officeDefs { get; }
    }

    public interface IOfficeDef
    {
        string name { get; }

        IResponsibility responsibility { get; }

        public interface IResponsibility
        {

        }
    }

    public interface IChaotingOfficeDef : IOfficeDef
    {
        bool isMain { get; }
    }

    public interface IHougongOfficeDef : IOfficeDef
    {

    }
}
