using IntelliTect.TestTools.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment5.Tests
{
    [TestClass]
    public class RealConsoleTests
    {
        [TestMethod]
        public void ReadLine_ReadsLineFromConsole()
        {
            var console = new RealConsole();

            ConsoleAssert.Expect("<<Testing line", () => console.ReadLine());
        }

        [TestMethod]
        public void WriteLine_OutputsLineOnTheConsole()
        {
            var console = new RealConsole();

            ConsoleAssert.Expect(">>Output line", () => console.WriteLine("Output line"));
        }
    }
}
