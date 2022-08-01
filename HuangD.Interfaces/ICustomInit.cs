using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.Interfaces
{
    public interface ICustomInit
    {
        IEmperorInit emperor { get; }
        ICounrtyInit country { get; }

        int money { get; }
    }
}
