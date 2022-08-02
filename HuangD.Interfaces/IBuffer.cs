using System;
using System.Collections.Generic;

namespace HuangD.Interfaces
{
    public interface IBuffer
    {
        (int year, int month, int day) startDate { get; }
        IBufferDef def { get; }
    }

    public interface IBufferDef
    {
        string name { get; }
        IEnumerable<IEffectDef> effects { get; }
    }

    public interface IProviceBufferDef : IBufferDef
    {
        Func<IProvince, IDate, bool> isStart { get; }
        Func<IProvince, IDate, bool> isEnd { get; }

    }

    public interface IEffectDef
    {
        int Value { get; }
        string name { get; }
    }

    public interface IPopTaxEffectDef : IEffectDef
    {
    }
}
