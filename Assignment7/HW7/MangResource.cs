using System;
using System.IO;


namespace HW7
{
    public class MangResource : IDisposable
    {
        public StreamReader FileReader { get; }
        public static int TotalNumOfResources { get; set; } = 0;

        public MangResource(string fileName)
        {
            FileReader = new StreamReader(fileName);
            TotalNumOfResources++;
        }

        ~MangResource()
        {
            Dispose();
        }

        public void Dispose()
        {
            FileReader?.Dispose();
            TotalNumOfResources--;
        }
    }
}
