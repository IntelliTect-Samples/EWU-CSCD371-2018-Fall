using System;
using System.IO;

namespace ResourceManager
{
    public class ResourceManager : IDisposable
    {
        public StreamReader FileChecker { get; }
        public static int Count { get; set; } = 0;

        public ResourceManager()
        {
            FileChecker = new StreamReader(@"C:\ProgramData\Temp\testFile1.txt");
            Count++;
        }

        public ResourceManager(string fileName)
        {
            FileChecker = new StreamReader(fileName);
            Count++;
        }

        public void Dispose()
        {
            // if the programmer remembers to call Dispose, this code will fire
            // Suppress finalization, in case of explicit Dispose call
            GC.SuppressFinalize(this);
            FileChecker?.Dispose();
            Count--;

        }

        ~ResourceManager()
        {
            // if the programmer does not remember to call Dispose, this finalizer will fire, 
            // and so the Dispose method and decrementer will fire event if they forget
            // or don't realize that IDisposable is supported.

            Dispose();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine($"1: {ResourceManager.Count}");
            int instanceCount = ResourceManager.Count;
            ResourceManager myThirdFileChecker = null;
            myThirdFileChecker = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt");
            Console.WriteLine("Generation: {0}", GC.GetGeneration(myThirdFileChecker));
            Console.WriteLine($"2: {ResourceManager.Count}");
            myThirdFileChecker.Dispose();
            Console.WriteLine($"3: {ResourceManager.Count}");

        }

    }
}
