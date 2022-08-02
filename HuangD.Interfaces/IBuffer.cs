using System.Collections.Generic;

namespace HuangD.Interfaces
{
    public interface IBuffer
    {
        IEnumerable<IEffectDef> effects { get; }
    }

    public interface IEffectDef
    {
    }

    public interface IPopTaxEffectDef : IEffectDef
    {
        string name { get; }
        int Value { get; }
    }
}
