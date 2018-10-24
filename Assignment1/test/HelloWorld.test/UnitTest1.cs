using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.test
{
    [TestClass]
    public class HelloWorld_UnitTest1  
    {
        [TestMethod]
        public void Validat_HelloWorld_TestMethod()  
        {
            //*
            string myValue = "World";
            string exptectedOutput = $@">>Hello, what is your name?
<<{myValue}
>>Hello {myValue}!";
            //*/

            /*
            string exptectedOutput = @">>Hello, what is your name?
<<World
>>Hello World!";  //the @ allows for multiplle lines
            */

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(exptectedOutput, HelloWorld.Program.Main);
        }
    }
}
