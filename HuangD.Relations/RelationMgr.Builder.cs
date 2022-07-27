using HuangD.Interfaces;
using System;
using System.Collections.Generic;

namespace HuangD.Relations
{
    public partial class RelationMgr
    {
        public static class Builder
        {
            public static IRelationMgr Build(IList<IPerson> persons, IChaotingGroup chaoting)
            {
                var relation = new RelationMgr();
                return relation;
            }
        }
    }
}
