using HuangD.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HuangD.Entities
{
    public class Province : IProvince
    {
        public string name => def.name;

        private IProvinceDef def;

        public Province(IProvinceDef def)
        {
            this.def = def;
        }
    }
}
