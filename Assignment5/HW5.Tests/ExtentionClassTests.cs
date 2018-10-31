using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW5;
using System;

namespace HW5.Tests
{
    [TestClass]
    public class ExtentionClassTests
    {
        [TestMethod]
        public void MyExtension_PassingInAString_Success()
        {
            TestableConsole Testconsole = new TestableConsole();
            //var myProgram = new Program();
            Program.Console = Testconsole;

            string ConvertedString = "this string was lower case, test passes if it is all upper case!";
            ConvertedString.PublicAnnoucement();
           // Program.DisplayEvents();
            //Assert.AreEqual(ConvertedString, " THIS STRING WAS LOWER CASE, TEST PASSES IF IT IS ALL UPPER CASE!");
        }
        

    }
}
