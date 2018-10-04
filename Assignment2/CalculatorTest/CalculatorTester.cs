using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTest
{
    [TestClass]
    public class InputTests
    {
        [DataRow("5 + 5", "10")]
        [DataRow("5 +9", "14")]
        [DataRow("1+3", "4")]
        [DataTestMethod]
        public void UserInputPromptValid(string inputStr, string answer)
        {
            string inputStrNoSpace = Regex.Replace(inputStr, " ", "");
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStrNoSpace}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }

        [DataRow("99")]
        [DataRow("")]
        [DataRow(".5*999")]
        [DataRow("1plus3")]
        [DataTestMethod]
        public void UserInputPromptInvalid(string inputStr)
        {
            Assert.IsFalse(false);
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
            string inputStrNoSpace = Regex.Replace(inputStr, " ", "");
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStrNoSpace}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("-50+5", "-45")]
        [DataRow("-100+10000", "9900")]
        [DataRow("-9999+1", "-9998")]
        [DataTestMethod]
        public void AddNegPlusPos(string inputStr, string answer)
        {
            string inputStrNoSpace = Regex.Replace(inputStr, " ", "");
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStrNoSpace}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("50+-5", "45")]
        [DataRow("100+-10000", "-9900")]
        [DataRow("9999+-1", "9998")]
        [DataTestMethod]
        public void AddPosPlusNeg(string inputStr, string answer)
        {
            string inputStrNoSpace = Regex.Replace(inputStr, " ", "");
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStrNoSpace}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
        
        [DataRow("50+-5", "45")]
        [DataRow("100+-10000", "-9900")]
        [DataRow("9999+-1", "9998")]
        [DataTestMethod]
        public void AddMaxValue(string inputStr, string answer)
        {
            string inputStrNoSpace = Regex.Replace(inputStr, " ", "");
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStrNoSpace}={answer}";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(ExpectedOutput, Assignment2_Calculator.Calculator.Main);
        }
    }
}