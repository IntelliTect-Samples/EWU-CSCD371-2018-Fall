using IntelliTect.TestTools.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment5.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void MainRunsEventManager()
        {
            ConsoleAssert.Expect(@"What do you want to do?
1. Create a course
2. Create an event
3. List events
4. Exit<<4", Program.Main);
        }
    }
}