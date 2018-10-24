using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interface.Tests
{
    [TestClass]
    public class RealConsoleTests
    {
        [TestMethod]
        public void WriteLineOutputsText()
        {
            //Arrange
            var console = new RealConsole();

            //Act
            console.WriteLine("Foo");

            //Assert
            //use ConsoleAssert
        }
    }
}