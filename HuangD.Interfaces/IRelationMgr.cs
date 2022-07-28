using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.Interfaces
{
    public interface IRelationMgr
    {
        IList<IPerson2Office> person2Offices { get; }
        IList<IPerson2Party> person2Parties { get; }
    }
}
