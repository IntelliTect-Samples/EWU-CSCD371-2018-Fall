using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7
{
    public class DisposableItem : IDisposable
    {
        public static int ResourcesAvailable { get; private set; } = 2;
        public bool Disposed { get; private set; }

        public DisposableItem()
        {
            if (!(ResourcesAvailable > 0))
            {
                Disposed = true;
                throw new InvalidOperationException("No resources available on call to DisposableItem CTOR.");
            }
            ResourcesAvailable--;
            Disposed = false;
        }

        private void Dispose(bool disposeOfResource)
        {
            if (Disposed)
            {
                return;
            }
            if (disposeOfResource)
            {
                ResourcesAvailable++;
                Disposed = true;
            }
            
        }

        public void Dispose()
        {
            Dispose(true);
        }

        //Override Object.Finalize()
        ~DisposableItem()
        {
            Dispose(true);
        }

        
    }
}
