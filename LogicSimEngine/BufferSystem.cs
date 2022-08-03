using LogicSimEngine.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LogicSimEngine
{
    public class BufferSystem
    {
        public void Process(IBufferOwner owner, IContext context, IEnumerable<IBufferDef> defs)
        {
            context.ext = owner.context;

            var needRemoveBuffers = owner.buffers.Where(x => x.def.isEnd(context)).ToArray();
            var needAddBufferDefs = defs.Where(x => x.isStart(context) && owner.buffers.All(buff => buff.def != x)).ToArray();

            foreach (var buffer in needRemoveBuffers)
            {
                owner.buffers.Remove(buffer);
            }
            foreach (var def in needAddBufferDefs)
            {
                owner.buffers.Add(new Buffer(def));
            }

            context.ext = null;
        }
    }
}