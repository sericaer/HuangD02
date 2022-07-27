using System.Collections.Generic;
using System.Linq;

namespace HuangD.Interfaces
{
    public interface IOffice
    {
        string name { get; }

        //IResponsibility responsibility { get; }
        IEnumerable<IPerson2Office> toPersonRelations { get; }
        IPerson currPerson => toPersonRelations.SingleOrDefault(x => x.isCurrent)?.person;

        public interface IResponsibility
        {

        }
    }
}
