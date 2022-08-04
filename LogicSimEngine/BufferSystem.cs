using LogicSimEngine.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LogicSimEngine
{
    public class BufferSystem
    {
        private GRandom random;

        public BufferSystem(GRandom random)
        {
            this.random = random;
        }

        public IEnumerable<IEvent> Process(IBufferOwner owner, IContext context, IEnumerable<IBufferDef> defs)
        {
            context.ext = owner.context;

            var needRemoveBuffers = owner.buffers.Where(x => x.def.isEnd(context)).ToArray();
            var needAddBufferDefs = defs.Where(x => x.isStart(context) && owner.buffers.All(buff => buff.def != x)).ToArray();

            foreach (var buffer in needRemoveBuffers)
            {
                if(random.isTrue(buffer.def.endRandom))
                {
                    if(buffer.def.endEvent != null)
                    {
                        var eventObj = new Event(buffer.def.endEvent, context);
                        eventObj.OnExit = ()=> owner.buffers.Remove(buffer);

                        yield return eventObj;
                    }
                    else
                    {
                        owner.buffers.Remove(buffer);
                    }

                }
            }
            foreach (var def in needAddBufferDefs)
            {
                if(random.isTrue(def.startRandom))
                {
                    if (def.startEvent != null)
                    {
                        var eventObj = new Event(def.startEvent, context);
                        eventObj.OnExit = () => owner.buffers.Add(new Buffer(def));

                        yield return eventObj;
                    }
                    else
                    {
                        owner.buffers.Add(new Buffer(def));
                    }

                }
            }

            context.ext = null;
        }
    }
}