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
        IOffice.IResponsibility responsibility { get; }
    }
}
