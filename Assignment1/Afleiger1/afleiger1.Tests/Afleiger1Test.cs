using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntelliTect.TestTools.Console;
using System;

namespace Afleiger1Test
{
    [TestClass]
    public class AfleigerTest1
    {
        [TestMethod]
        public void AfleigerTestText()
        {
            String expectedValue = "Test String Test";

            ConsoleAssert.Expect($@">>Waiting for input...
<<{expectedValue}
>>You provided:{expectedValue}", Afleiger1.Afleiger1.Main);
        }
    }
}
