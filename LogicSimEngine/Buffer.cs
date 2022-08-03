using LogicSimEngine.Interfaces;

namespace LogicSimEngine
{
    public class Buffer : IBuffer
    {
        public IBufferDef def { get; }

        public (int year, int month, int day) startDate { get; }

        public Buffer(IBufferDef def)
        {
            this.def = def;
        }
    }
}
