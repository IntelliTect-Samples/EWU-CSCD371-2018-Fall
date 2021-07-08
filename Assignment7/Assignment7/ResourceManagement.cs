using System;
using System.IO;

namespace Assignment7UnitTest
{
    public class ResourceManagement : IDisposable
    {
        private StreamReader FileReader { get; }
        public static int count = 0;

        public ResourceManagement()
        {
        }

        public ResourceManagement(string fileName)
        {
            FileReader = new StreamReader(fileName);
            count++;
        }

        ~ResourceManagement()
        {
            Dispose();
        }

        public void Dispose()
        {
            FileReader?.Dispose();
            count--;
        }

    }
}