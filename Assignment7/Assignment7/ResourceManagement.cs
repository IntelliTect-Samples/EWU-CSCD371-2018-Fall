using System;
using System.IO;

namespace Assignment7
{
    public class ResourceManagement : IDisposable
    {
        public StreamReader FileChecker { get; }
        public static int resources = 0;

        public ResourceManagement(string fileName)
        {
            FileChecker = new StreamReader(fileName);
            resources++;
        }
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                FileChecker?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            resources--;
        }

        ~ResourceManagement()
        {
            //run dispose method if programmer forgot.
            Dispose(false);
        }
    }
}