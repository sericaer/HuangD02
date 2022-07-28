﻿using System.Collections.Generic;

namespace HuangD.Interfaces
{
    public interface IModder
    {
        IModDefs defs { get; }
    }

    public interface IModDefs
    {
        IPersonDef personDef { get; }
        IEnumerable<IOfficeDef> officeDefs { get; }
    }

    public interface IOfficeDef
    {
        string name { get; }

        RespType responsibility { get; }

        public interface IResponsibility
        {

        }

        public enum RespType
        {
            Empty,
            HuangHou,
            Gui,
            Fei,
            Bin,
        }
    }

    public interface IChaotingOfficeDef : IOfficeDef
    {
        bool isMain { get; }
    }

    public interface IHougongOfficeDef : IOfficeDef
    {
        int maxCount { get; }
    }

    public interface IPersonDef
    {
        string[] familyNames { get; }
        string[] givenNames { get; }

    }
}
