using HuangD.Entities;
using HuangD.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace HuangD.Systems
{
    public class ProvinceBufferSystem
    {
        private IEnumerable<IProviceBufferDef> bufferDefs;

        public ProvinceBufferSystem(IEnumerable<IProviceBufferDef> bufferDefs)
        {
            this.bufferDefs = bufferDefs;
        }

        public void Process(IList<IProvince> provinces, IDate date)
        {
            //foreach(var province in provinces)
            //{
            //    var needRemoveBuffers = province.buffers.Where(x => ((IProviceBufferDef)x.def).isEnd(province, date)).ToArray();
            //    var needAddBufferDefs = bufferDefs.Where(x => x.isStart(province, date) && province.buffers.All(buff => buff.def != x)).ToArray();

            //    foreach(var buffer in needRemoveBuffers)
            //    {
            //        province.buffers.Remove(buffer);
            //    }
            //    foreach (var def in needAddBufferDefs)
            //    {
            //        province.buffers.Add(new Buffer(def, date));
            //    }
            //}
        }
    }
}
