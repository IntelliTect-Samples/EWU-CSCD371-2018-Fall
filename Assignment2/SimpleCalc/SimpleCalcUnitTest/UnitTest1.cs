using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalcUnitTest
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void TestMethodForAddition()
        {
            string ArarithmeticExpression = "2+2";
            string expectedOutput = $@">>Please enter an arithmetic expression: 
<<{ArarithmeticExpression}
>>Your answer is: 4";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SimpleCalc.SimpleCalcProgram.Main);
        }

        [TestMethod]
        public void TestMethodForAdditionMinVAl()
        { 
            string ArarithmeticExpression = $"{Int32.MinValue}+{Int32.MinValue}";
            string expectedOutput = $@">>Please enter an arithmetic expression: 
<<{ArarithmeticExpression}
>>Your answer is: 0";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SimpleCalc.SimpleCalcProgram.Main);
        }

        [TestMethod]
        public void TestMethodForAdditionMinVAlPlus()
        {
            string ArarithmeticExpression = $"{Int32.MinValue}-{Int32.MinValue}";
            string expectedOutput = $@">>Please enter an arithmetic expression: 
<<{ArarithmeticExpression}
>>Your answer is: 0";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SimpleCalc.SimpleCalcProgram.Main);
        }



        [TestMethod]
        public void TestMethodForSubtraction()
        {
            string ArarithmeticExpression = "4-2";
            string expectedOutput = $@">>Please enter an arithmetic expression: 
<<{ArarithmeticExpression}
>>Your answer is: 2";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SimpleCalc.SimpleCalcProgram.Main);
        }

        [TestMethod]
        public void TestMethodForMultiplication()
        {
            string ArarithmeticExpression = "2*2";
            string expectedOutput = $@">>Please enter an arithmetic expression: 
<<{ArarithmeticExpression}
>>Your answer is: 4";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SimpleCalc.SimpleCalcProgram.Main);
        }

        [TestMethod]
        public void TestMethodForDivision()
        {
            string ArarithmeticExpression = "4/2";
            string expectedOutput = $@">>Please enter an arithmetic expression: 
<<{ArarithmeticExpression}
>>Your answer is: 2";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, SimpleCalc.SimpleCalcProgram.Main);
        }

    }
}
