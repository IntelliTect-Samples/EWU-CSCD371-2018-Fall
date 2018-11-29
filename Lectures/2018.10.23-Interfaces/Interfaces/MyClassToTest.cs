using System;

namespace Interfaces
{
    public class MyClassToTest
    {
        private IMyConsole Console { get; }

        public MyClassToTest(IMyConsole console = null)
        {
            Console = console;
        }

        public void DoStuff()
        {
            //if (Console != null)
            //{
            //    Console.WriteLine("Stuff");
            //}
            //Console?.WriteLine("Stuff");
            //
            int? hashCode = Console?.GetHost()?.GetHashCode();
            
            Console?.WriteLine((hashCode?.ToString()) ?? "");

        }
    }
}