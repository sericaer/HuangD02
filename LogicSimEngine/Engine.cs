using System;

namespace LogicSimEngine
{
    public class Engine
    {
        public GRandom random;

        public BufferSystem bufferSystem { get; }

        public Engine(string seed)
        {
            random = new GRandom(seed);
            bufferSystem = new BufferSystem(random);
        }
    }
}
