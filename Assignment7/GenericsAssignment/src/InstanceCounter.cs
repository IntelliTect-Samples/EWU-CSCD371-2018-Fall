using System;
using System.Threading;

namespace src
{
    public class InstanceCounter : IDisposable
    {
        public static int InstanceCount{ get; private set; }

        public Barrier Barrier { get; set; }

        public InstanceCounter()
        {
            Barrier = new Barrier(1);
            InstanceCount++;
        }
        
        public void Dispose()
        {
            Barrier.Dispose();
            InstanceCount--;
        }

        ~InstanceCounter()
        {
            Dispose();
        }
    }
}
