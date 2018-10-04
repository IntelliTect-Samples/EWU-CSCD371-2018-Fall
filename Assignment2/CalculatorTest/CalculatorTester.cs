using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    [TestClass]
    public class InputTests
    {
        /**
         * Note that for tester simplicity i did not include spaces in the
         * input with the exception of this method
         */
        [DataRow("5 + 5", "10")]
        [DataRow("5 +9", "14")]
        [DataRow("1+3", "4")]
        [DataTestMethod]
        public void UserInputPromptValid(string inputStr, string answer)
        {
            var inputStrNoSpace = Regex.Replace(inputStr, " ", "");
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStrNoSpace}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }

        [DataRow("99")]
        [DataRow("--9/80")]
        [DataRow("")]
        [DataRow(".5*999")]
        [DataRow("1plus3")]
        [DataTestMethod]
        public void UserInputPromptInvalid(string inputStr)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
>>Invalid Expression: {inputStr}
>>Please enter an expression ie. (3+1): <<1+1
>>1+1=2";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
    }
    
    
    
    

    [TestClass]
    public class AdditionIntegerTests
    {
        [DataRow("50+5", "55")]
        [DataRow("100+10000", "10100")]
        [DataRow("9999+1", "10000")]
        [DataTestMethod]
        public void AddPositive(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("-50+5", "-45")]
        [DataRow("-100+10000", "9900")]
        [DataRow("-9999+1", "-9998")]
        [DataTestMethod]
        public void AddNegPlusPos(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("50+-5", "45")]
        [DataRow("100+-10000", "-9900")]
        [DataRow("9999+-1", "9998")]
        [DataTestMethod]
        public void AddPosPlusNeg(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("2147483647+2", "2147483649")]
        [DataRow("2+2147483647", "2147483649")]
        [DataRow("2147483647+-100", "2147483547")]
        [DataRow("2147483647+2147483647", "4294967294")]
        [DataTestMethod]
        public void AddMaxValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("-2147483647+2", "-2147483645")]
        [DataRow("2+-2147483647", "-2147483645")]
        [DataRow("-2147483647+-100", "-2147483747")]
        [DataRow("-2147483647+-2147483647", "-4294967294")]
        [DataTestMethod]
        public void AddMinValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
    }
    
    
    
    
    
    
    [TestClass]
    public class SubtractionIntegerTests
   
    {
        [DataRow("50-5", "45")]
        [DataRow("100-10000", "-9900")]
        [DataRow("9999-1", "9998")]
        [DataTestMethod]
        public void SubtractPositive(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("-50-5", "-55")]
        [DataRow("-100-10000", "-10100")]
        [DataRow("-9999-1", "-10000")]
        [DataTestMethod]
        public void SubtractNegMinusPos(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("50--5", "55")]
        [DataRow("10--10000", "10100")]
        [DataRow("9999--1", "1000")]
        [DataTestMethod]
        public void SubtractPosMinusNeg(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("2147483647-2", "2147483645")]
        [DataRow("-2-2147483647", "-2147483649")]
        [DataRow("2147483647-100", "2147483547")]
        [DataRow("-2147483647-2147483647", "-4294967294")]
        [DataTestMethod]
        public void SubtractMaxValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("-2147483647-2", "2147483649")]
        [DataRow("2--2147483647", "2147483645")]
        [DataRow("-2147483647-100", "-2147483747")]
        [DataRow("-2147483647--2147483647", "0")]
        [DataTestMethod]
        public void SubtractMinValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
    }
}