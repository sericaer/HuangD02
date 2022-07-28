using HuangD.Interfaces;
using System;
using System.Collections.Generic;

namespace HuangD.Relations
{
    public partial class RelationMgr : IRelationMgr
    {
        public IList<IPerson2Office> person2Offices { get; } = new List<IPerson2Office>();

        public IList<IPerson2Party> person2Parties { get; } = new List<IPerson2Party>();
    }
}
