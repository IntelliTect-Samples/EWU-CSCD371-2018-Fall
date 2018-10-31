using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment5.Tests
{
    [TestClass]
    public class TestRealConsole
    {
        private RealConsole consoleToUse;

        [TestInitialize]
        public void Initialize()
        {
            consoleToUse = new RealConsole();
        }
        
        [TestMethod]
        public void IConsoleWriteLine_TestValidOutput()
        {
        }
    }
}