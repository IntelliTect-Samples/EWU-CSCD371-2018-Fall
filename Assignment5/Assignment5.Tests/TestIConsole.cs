using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment5.Tests
{
    [TestClass]
    public class TestIConsole
    {
        private TestConsole _mockConsole;

        [TestInitialize]
        public void Initialize()
        {
            _mockConsole = new TestConsole();
        }
        
        [DataTestMethod]
        [DataRow("test")]
        [DataRow("C#")]
        [DataRow("Something With Spaces")]
        [DataRow("12")]
        public void IConsoleWriteLine_TestValidOutput(string toWrite)
        {
            _mockConsole.WrittenLine = toWrite;
            
            Assert.AreEqual(toWrite, _mockConsole.WrittenLine);
        }
        
        [DataTestMethod]
        [DataRow("test")]
        [DataRow("C#")]
        [DataRow("Something With Spaces")]
        [DataRow("12")]
        public void IConsoleWriteLine_TestValidInput(string toWrite)
        {
            _mockConsole.WrittenLine = toWrite;
            
            Assert.AreEqual(toWrite, _mockConsole.ReadLine());
        }
    }

    public class TestConsole : IConsole
    {
        public string WrittenLine { get; set; }
        
        public void WriteLine(string toWrite)
        {
            WrittenLine = toWrite;
        }

        public string ReadLine()
        {
            return WrittenLine;
        }
    }
}