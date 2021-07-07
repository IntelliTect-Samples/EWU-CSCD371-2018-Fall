using System;

namespace Assignment7
{
    public class MyDisposableClass
    {
        private bool Disposed { get; set; }

        public static int InstantiationCount { get; private set; }

        public MyDisposableClass()
        {
            InstantiationCount++;
        }

        public static void ResetInstantiationCount()
        {
            InstantiationCount = 0;
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                InstantiationCount--;
                GC.SuppressFinalize(this);
            }

            Disposed = true;
        }

        ~MyDisposableClass()
        {
            Dispose();
        }

        public static void MakeSomeGarbageForGarbageCollector()
        {
            MyDisposableClass someClass = new MyDisposableClass();
            MyDisposableClass someClass2 = new MyDisposableClass();
            MyDisposableClass someClass3 = new MyDisposableClass();

            //intentionally leaving these objects for the GC to pick up.
        }

        public static void Main()
        {

        }
    }
}