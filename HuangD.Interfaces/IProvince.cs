using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.Interfaces
{
    public interface IProvince
    {
        string name { get; }
        IOffice masterOffice { get; }
        int popCount => 1000; 
    }
}
