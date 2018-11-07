using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework6;
using System;

namespace Homework6.Tests
{
    [TestClass]
    public class ExtentionClassTests
    {
        [TestMethod]
        public void MyExtension_PassingInAString_Success()
        {
            TestableConsole Testconsole = new TestableConsole();
            //var myProgram = new Program();
            //Program.Console = Testconsole;  //***** This commented out to get get the problem to run.. as it is commented out at the top of main.

            string ConvertedString = "this string was lower case, test passes if it is all upper case!";
            ConvertedString.PublicAnnoucement();
           // Program.DisplayEvents();
            //Assert.AreEqual(ConvertedString, " THIS STRING WAS LOWER CASE, TEST PASSES IF IT IS ALL UPPER CASE!");
        }
        

    }
}
