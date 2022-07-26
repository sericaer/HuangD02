using HuangD.CustomInits;
using HuangD.Interfaces;
using HuangD.Modders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Global
{
    public static ISession session = null;
    public static ICustomInit customInit = CustomInit.Default;
    public static IModder modder = Modder.Default;
}
