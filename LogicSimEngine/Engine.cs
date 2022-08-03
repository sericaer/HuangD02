using System;

namespace LogicSimEngine
{
    public class Engine
    {
        public BufferSystem bufferSystem { get; }

        public Engine()
        {
            bufferSystem = new BufferSystem();
        }
    }
}
