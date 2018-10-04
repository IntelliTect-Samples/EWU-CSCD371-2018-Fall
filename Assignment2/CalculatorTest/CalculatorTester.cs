using System.Text.RegularExpressions;
using Assignment2_Calculator;
using IntelliTect.TestTools.Console;
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
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
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
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
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
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("-50+5", "-45")]
        [DataRow("-100+10000", "9900")]
        [DataRow("-9999+1", "-9998")]
        [DataTestMethod]
        public void AddNegPlusPos(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("50+-5", "45")]
        [DataRow("100+-10000", "-9900")]
        [DataRow("9999+-1", "9998")]
        [DataTestMethod]
        public void AddPosPlusNeg(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
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
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
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
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
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
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("-50-5", "-55")]
        [DataRow("-100-10000", "-10100")]
        [DataRow("-9999-1", "-10000")]
        [DataTestMethod]
        public void SubtractNegMinusPos(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("50--5", "55")]
        [DataRow("10--10000", "10010")]
        [DataRow("9999--1", "10000")]
        [DataTestMethod]
        public void SubtractPosMinusNeg(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
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
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("200--2147483647", "2147483847")]
        [DataRow("2--2147483647", "2147483649")]
        [DataRow("-2147483647-100", "-2147483747")]
        [DataRow("-2147483647--2147483647", "0")]
        [DataTestMethod]
        public void SubtractMinValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }
    }


    [TestClass]
    public class MultiplicationIntegerTests
    {
        [DataRow("50*5", "250")]
        [DataRow("20*10000", "200000")]
        [DataRow("9999*2", "19998")]
        [DataRow("1001*0", "0")]
        [DataTestMethod]
        public void MultiplyPositive(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("-50*5", "-250")]
        [DataRow("-20*10000", "-200000")]
        [DataRow("-9999*2", "-19998")]
        [DataRow("-1001*0", "0")]
        [DataTestMethod]
        public void MultiplyNegTimesPos(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("50*-5", "-250")]
        [DataRow("20*-10000", "-200000")]
        [DataRow("9999*-2", "-19998")]
        [DataRow("0*-1001", "0")]
        [DataTestMethod]
        public void MultiplyPosTimesNeg(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("2147483647*2", "4294967294")]
        [DataRow("2*2147483647", "4294967294")]
        [DataRow("2147483647*-100", "-214748364700")]
        [DataRow("2147483647*2147483647", "4.61168601413242E+18")]
        [DataTestMethod]
        public void MultiplyMaxValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("-2147483647*2", "-4294967294")]
        [DataRow("2*-2147483647", "-4294967294")]
        [DataRow("-2147483647*-100", "214748364700")]
        [DataRow("-2147483647*-2147483647", "4.61168601413242E+18")]
        [DataTestMethod]
        public void MultiplyMinValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }
    }


    [TestClass]
    public class DivisionIntegerTests
    {
        [DataRow("50/5", "10")]
        [DataRow("10000/20", "500")]
        [DataRow("9999/9", "1111")]
        [DataRow("100/10", "10")]
        [DataRow("1/2", "0.5")]
        [DataTestMethod]
        public void DividePositive(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("-50/5", "-10")]
        [DataRow("-10000/20", "-500")]
        [DataRow("-9999/9", "-1111")]
        [DataRow("-100/10", "-10")]
        [DataRow("-1/2", "-0.5")]
        [DataTestMethod]
        public void DivideNegDividePos(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("50/-5", "-10")]
        [DataRow("10000/-20", "-500")]
        [DataRow("9999/-9", "-1111")]
        [DataRow("100/-10", "-10")]
        [DataRow("1/-2", "-0.5")]
        [DataTestMethod]
        public void DividePosDivideNeg(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("2147483647/2", "1073741823.5")]
        [DataRow("200/2147483647", "9.31322575049159E-08")]
        [DataRow("2147483647/-100", "-21474836.47")]
        [DataRow("2147483647/2147483647", "1")]
        [DataTestMethod]
        public void DivideMaxValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("-2147483647/2", "-1073741823.5")]
        [DataRow("200/-2147483647", "-9.31322575049159E-08")]
        [DataRow("-2147483647/-100", "21474836.47")]
        [DataRow("-2147483647/-2147483647", "1")]
        [DataTestMethod]
        public void DivideMinValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("-150/0")]
        [DataRow("200/0")]
        [DataRow("-9/0")]
        [DataRow("63/0")]
        [DataTestMethod]
        public void DivideByZero(string inputStr)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
>>Cannot divide by zero: {inputStr}
>>Please enter an expression ie. (3+1): <<1+1
>>1+1=2";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }
    }


    [TestClass]
    public class ModularIntegerTests
    {
        [DataRow("50%7", "1")]
        [DataRow("10000%19", "6")]
        [DataRow("9999%8", "7")]
        [DataRow("100%9", "1")]
        [DataRow("1%2", "1")]
        [DataTestMethod]
        public void ModPositive(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("-50%7", "-1")]
        [DataRow("-10000%19", "-6")]
        [DataRow("-9999%8", "-7")]
        [DataRow("-100%9", "-1")]
        [DataRow("-1%2", "-1")]
        [DataTestMethod]
        public void ModNegModPos(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("50%-7", "1")]
        [DataRow("10000%-19", "6")]
        [DataRow("9999%-8", "7")]
        [DataRow("100%-9", "1")]
        [DataRow("1%-2", "1")]
        [DataTestMethod]
        public void ModPosModNeg(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("2147483647%4", "3")]
        [DataRow("200%2147483647", "200")]
        [DataRow("2147483647%-100", "47")]
        [DataRow("2147483647%2147483647", "0")]
        [DataTestMethod]
        public void ModMaxValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("-2147483647%4", "-3")]
        [DataRow("200%-2147483647", "200")]
        [DataRow("-2147483647%-100", "-47")]
        [DataRow("-2147483647%-2147483647", "0")]
        [DataTestMethod]
        public void ModMinValue(string inputStr, string answer)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
            >>{inputStr}={answer}";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }

        [DataRow("-150%0")]
        [DataRow("200%0")]
        [DataRow("-9%0")]
        [DataRow("63%0")]
        [DataTestMethod]
        public void ModByZero(string inputStr)
        {
            var ExpectedOutput = $@">>Please enter an expression ie. (3+1): <<{inputStr}
>>Cannot mod by zero: {inputStr}
>>Please enter an expression ie. (3+1): <<1+1
>>1+1=2";
            ConsoleAssert.Expect(ExpectedOutput, Calculator.Main);
        }
    }





    [TestClass]
    public class StringTests
    {
        [DataRow("Casey", "White")]
        [DataRow("Easy", "Test")]
        [DataRow("Cake", "Walk")]
        [DataTestMethod]
        public void TestLengthEqual(string str1, string str2)
        {
            Assert.AreEqual(str1.Length, str2.Length);
        }

        [DataRow("Casey", "Test")]
        [DataRow("Easy", "White")]
        [DataRow("Cake", "Wow")]
        [DataTestMethod]
        public void TestLengthUnqual(string str1, string str2)
        {
            Assert.AreNotEqual(str1.Length, str2.Length);
        }

        [DataRow("Casey", "Casey")]
        [DataRow("Easy", "Easy")]
        [DataRow("Cake", "Cake")]
        [DataTestMethod]
        public void TestStringCompareEqual(string str1, string str2)
        {
            var comparison = str1.CompareTo(str2);
            Assert.AreEqual(0, comparison);
        }

        [DataRow("Casey", "White")]
        [DataRow("Easy", "Test")]
        [DataRow("Cake", "Walk")]
        [DataTestMethod]
        public void TestStringCompareUnequal(string str1, string str2)
        {
            var comparison = str1.CompareTo(str2);
            Assert.AreNotEqual(0, comparison);
        }

        [DataRow("Casey", "Casey")]
        [DataRow("Easy", "Easy")]
        [DataRow("Cake", "Cake")]
        [DataTestMethod]
        public void TestStringEqualsEqual(string str1, string str2)
        {
            Assert.IsTrue(str1.Equals(str2));
        }

        [DataRow("Casey", "White")]
        [DataRow("Easy", "Test")]
        [DataRow("Cake", "Walk")]
        [DataTestMethod]
        public void TestStringEqualsUnequal(string str1, string str2)
        {
            Assert.IsFalse(str1.Equals(str2));
        }

        [DataRow("Casey", "ey")]
        [DataRow("Easy", "as")]
        [DataRow("Cake", "ke")]
        [DataTestMethod]
        public void TestStringContains(string str1, string str2)
        {
            Assert.IsTrue(str1.Contains(str2));
        }

        [DataRow("Casey", "wow")]
        [DataRow("Easy", "not")]
        [DataRow("Cake", "here")]
        [DataTestMethod]
        public void TestStringNotContains(string str1, string str2)
        {
            Assert.IsFalse(str1.Contains(str2));
        }
    }
}