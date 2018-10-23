using Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interface.Tests
{
    [TestClass]
    public class MyClassToTest_Tests
    {
        [TestMethod]
        public void DoStuff_OutputsStuff()
        {
            //Arrange
            TestableConsole console = new TestableConsole();
            var sut = new MyClassToTest();

            //Act
            sut.DoStuff();

            //Assert
            Assert.AreEqual("Stuff", console.LastWrittenLine);
        }
    }

    public class TestableConsole : IMyConsole
    {
        public string LastWrittenLine { get; private set; }

        public void WriteLine(string line)
            => LastWrittenLine = line;
    }
}
