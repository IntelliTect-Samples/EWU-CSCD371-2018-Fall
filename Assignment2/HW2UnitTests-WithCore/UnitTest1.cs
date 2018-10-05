using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW2UnitTests
{
    [TestClass]
    public class myCalculatorUnitTests
    {
        [TestMethod]
        public void AddTwoPositiveNumbers_bothNumbersAreValidDoubles()
        {
            // Arrange                        
            double A = 2.1;
            double B = 5.3;            
            double expectedResult = A + B;
            string myValue = $"{A}+{B}";
            
            // Act
            string exptectedOutput = $@">>No command line argument given. Please manually enter an expression.
>>Enter an expression (ie. 1+3 with no spaces) and then press Enter.
<<{myValue}
>>={expectedResult}
>>Press any key to quit
";            
            // Assert
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(exptectedOutput, Assignment2.Calculator.Main);
        }

        [TestMethod]
        public void AddTwoPositiveNumbers_bothNumbersAreValidDoubles_BothHaveExtraWhiteSpace()
        {
            // Arrange                        
            double A = 2.1;
            double B = 5.3;
            double expectedResult = A + B;
            string myValue = $" {A} + {B} ";

            // Act
            string exptectedOutput = $@">>No command line argument given. Please manually enter an expression.
>>Enter an expression (ie. 1+3 with no spaces) and then press Enter.
<<{myValue}
>>={expectedResult}
>>Press any key to quit
";
            // Assert
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(exptectedOutput, Assignment2.Calculator.Main);
        }

        [TestMethod]
        public void AddTwoPositiveNumbers_bothNumbersChars()
        {
            // Arrange                        
            string myValue = $"A+B";

            // Act
            string exptectedOutput = $@">>No command line argument given. Please manually enter an expression.
>>Enter an expression (ie. 1+3 with no spaces) and then press Enter.
<<{myValue}
>>First number was invalid.
>>Last number was invalid.
>>=0
>>Press any key to quit
";
            // Assert
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(exptectedOutput, Assignment2.Calculator.Main);
        }


        [TestMethod]
        public void SubtractTwoPositiveNumbers_bothNumbersAreValidDoubles()
        {
            // Arrange                        
            double A = 2.1;
            double B = -5.3;
            double expectedResult = A - B;
            string myValue = "2.1--5.3";

            // Act
            string exptectedOutput = $@">>No command line argument given. Please manually enter an expression.
>>Enter an expression (ie. 1+3 with no spaces) and then press Enter.
<<{myValue}
>>={expectedResult}
>>Press any key to quit
";
            // Assert
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(exptectedOutput, Assignment2.Calculator.Main);
        }

        [TestMethod]
        public void MultiplyTwoPositiveNumbers_bothNumbersAreValidDoubles()
        {
            // Arrange                        
            double A = 2.1;
            double B = -5.3;
            double expectedResult = A * B;
            string myValue = "2.1*-5.3";

            // Act
            string exptectedOutput = $@">>No command line argument given. Please manually enter an expression.
>>Enter an expression (ie. 1+3 with no spaces) and then press Enter.
<<{myValue}
>>={expectedResult}
>>Press any key to quit
";
            // Assert
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(exptectedOutput, Assignment2.Calculator.Main);
        }

        [TestMethod]
        public void DivideTwoPositiveNumbers_bothNumbersAreValidDoubles()
        {
            // Arrange                        
            double A = -12.34;
            double B = 43.21;
            double expectedResult = A / B;
            string myValue = "-12.34/43.21";

            // Act
            string exptectedOutput = $@">>No command line argument given. Please manually enter an expression.
>>Enter an expression (ie. 1+3 with no spaces) and then press Enter.
<<{myValue}
>>={expectedResult}
>>Press any key to quit
";
            // Assert
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(exptectedOutput, Assignment2.Calculator.Main);
        }

        [TestMethod]
        public void DivideTwoNumbers_NumeratorIsAZero()
        {
            // Arrange                        
            double A = -12.34;
            double B = 0;
            double expectedResult = A / B;
            string myValue = "-12.34/0";

            // Act
            string exptectedOutput = $@">>No command line argument given. Please manually enter an expression.
>>Enter an expression (ie. 1+3 with no spaces) and then press Enter.
<<{myValue}
>>Error, can not divide by 0!!!
>>Press any key to quit
";
            // Assert
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(exptectedOutput, Assignment2.Calculator.Main);
        }

    }//end myCalculatorUnitTests class



    [TestClass]
    public class StringTests
    {

        [TestMethod]
        public void StartsWith_SearchForDR_usingAStringThatContainsDrInsideTheString()
        {
            // Arrange
            string str = "Im Dr. Smith";

            // Act
            bool result = str.StartsWith("Dr");

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void StartsWith_SearchForDR_usingaStringThatContainsDr()
        {
            // Arrange
            string str = "Dr. Howes";

            // Act
            bool result = str.StartsWith("Dr");

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void StartsWith_SearchForDR_usingaStringThatDoesNOTContainsDr()
        {
            // Arrange
            string str = "Mr. Howes";

            // Act
            bool result = str.StartsWith("Dr");

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Trim_TrimAStringWithWhiteSpaces()
        {
            // Arrange
            string str = "  This String Had Whitespaces At The Beginning And End!     ";
            string result;
            string expected = "This String Had Whitespaces At The Beginning And End!";
            // Act
            result = str.Trim();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Trim_TrimAStringWithNotContainingWhiteSpaces()
        {
            // Arrange
            string str = "This String Does Not Contain Whitespaces At The Beginning Or End!";
            string result;
            string expected = "This String Does Not Contain Whitespaces At The Beginning Or End!";
            // Act
            result = str.Trim();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToUpper_ConvertAStringToUpper_StringContainsAllUpperCharactors()
        {
            // Arrange
            string str = "THIS STRING WAS ALREADY UPPER CASE!";
            string result;
            string expected = "THIS STRING WAS ALREADY UPPER CASE!";
            // Act
            result = str.ToUpper();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ToUpper_ConvertAStringToUpper_StringContainsAllLowerCharactors()
        {
            // Arrange
            string str = "this string was all lower case!";
            string result;
            string expected = "THIS STRING WAS ALL LOWER CASE!";
            // Act
            result = str.ToUpper();

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Replace_ReplaceWithAWordNotContainedInTheString()
        {
            // Arrange
            string str = "The word to replace is not in this string";
            string result;
            string expected = "The word to replace is not in this string";
            // Act
            result = str.Replace("Mississippi", "Miss");

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Replace_ReplaceWithAWordThisIsContainedInTheString()
        {
            // Arrange
            string str = "The word to replace is in this string";
            string result;
            string expected = "The word to replace is in this sentance";
            // Act
            result = str.Replace("string", "sentance");

            // Assert
            Assert.AreEqual(expected, result);
        }
    }

}
