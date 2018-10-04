using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Assignment2.UnitTests
{

    [TestClass]
    public class StringUnitTests
    {

        [TestMethod]
        public void TestSubstring()
        {
            string toTest = "Essential C# 7.0";
            Assert.AreEqual(toTest.Substring(10, 2),"C#");
        }

        [TestMethod]
        public void TestStringCompareTo()
        {
            string fruit = "Apples";
            string veggie = "Squash";
            Assert.IsTrue(fruit.CompareTo(veggie) < 0) ;
            Assert.IsTrue(veggie.CompareTo(fruit) > 0);
            Assert.IsTrue(fruit.CompareTo(fruit) == 0);
        }
        [DataRow("Bonanza", "Bon", true)]
        [DataRow("Crabapples", "dog", false)]
        [DataRow("Micrsoft", "soft", true)]
        [DataRow("wow", "wow", true)]
        [TestMethod]
        public void TestStringContains(string word, string toFind, bool result)
        {
            Assert.AreEqual(word.Contains(toFind), result);
        }

        [TestMethod]
        public void TestStringLength()
        {
            string toTest = "0123456789";
            Assert.AreEqual(toTest.Length, 10);
        }

        [DataRow("Bonanza", "Bon", 0)]
        [DataRow("Crabapples", "d", -1)]
        [DataRow("Micrsoft", "s", 4)]
        [DataRow("wow", "wow", 0)]
        [TestMethod]
        public void TestStringIndexOf(string word, string toFind, int index)
        {
            Assert.AreEqual(word.IndexOf(toFind), index);
        }

        [DataRow("", true)]
        [DataRow(" ", false)]
        [DataRow(null, true)]
        [DataRow("Something", false)]
        [TestMethod]
        public void TestIsNullOrEmpty(string word, bool result)
        {
            Assert.AreEqual(String.IsNullOrEmpty(word), result);
        }

    }


        [TestClass]
    public class OutputExitTests
    {
        [TestMethod]
        public void TestExitProgram()
        {
            string userInput = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{userInput}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [TestMethod]
        public void TestExitCapsProgram()
        {
            string userInput = "EXIT";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{userInput}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

    }//Output/Exit Unit tests

    [TestClass]
    public class EdgeCaseTests
    {

        [TestMethod]
        public void EmptyLine()
        {
            string line = "";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [TestMethod]
        public void AddIntMinMaxValue()
        {
            StringBuilder sb = new StringBuilder(100);
            sb.Append($"{int.MaxValue.ToString()}+{int.MinValue.ToString()}");
            string answer = $"{sb.ToString()} = -1";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{sb.ToString()}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [TestMethod]
        public void AddIntMax()
        {
            StringBuilder sb = new StringBuilder(100);
            sb.Append($"{int.MaxValue.ToString()}+{int.MaxValue.ToString()}");
            string answer = $"{sb.ToString()} = {int.MaxValue * 2.0}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{sb.ToString()}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [DataRow("0/0")]
        [DataRow("10/0")]
        [DataRow("0/0.0")]
        [DataRow("10/0.0")]
        [TestMethod]
        public void DivideByZero(string line)
        {

            string error = $"Failed to evalute expression: {line}" +
                $"Reason: Attempted to divide by zero";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>Failed to evalute expression: { line}
Reason: Attempted to divide by zero.
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

    }//Edge Case tests


    [TestClass]
    public class BinomialEvaluationTests
    {
        [DataRow("2+2", "4")]
        [DataRow("2+-2", "0")]
        [DataRow("-2+5", "3")]
        [DataRow("-2+-2", "-4")]
        [DataRow("0+2", "2")]
        [DataRow("-0+-0", "0")]
        [TestMethod]
        public void AddIntegers(string line, string result)
        {
          
            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }


        [DataRow("2.2+2.2", "4.4")]
        [DataRow("2.2+-2.2", "0")]
        [DataRow("-2.7+5.2", "2.5")]
        [DataRow("-2.111+-2.11", "-4.221")]
        [DataRow("0.0+2.0", "2")]
        [DataRow("-0.0+-0.0", "0")]
        [TestMethod]
        public void AddDoubles(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [DataRow("2.2-2.2", "0")]
        [DataRow("2.2--2.2", "4.4")]
        [DataRow("-2.7-5.2", "-7.9")]
        [DataRow("-2.111--2.11", "-0.001")]
        [DataRow("0.0-2.0", "-2")]
        [DataRow("-0.0--0.0", "0")]
        [TestMethod]
        public void SubtractDoubles(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [DataRow("2-2", "0")]
        [DataRow("2--2", "4")]
        [DataRow("-2-5", "-7")]
        [DataRow("-2--4", "2")]
        [DataRow("0-2", "-2")]
        [DataRow("0-0", "0")]
        [TestMethod]
        public void SubtractIntegers(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [DataRow("2*2", "4")]
        [DataRow("2*-2", "-4")]
        [DataRow("-2*5", "-10")]
        [DataRow("-2*-4", "8")]
        [DataRow("0*2", "0")]
        [DataRow("0*0", "0")]
        [TestMethod]
        public void MultiplyIntegers(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [DataRow("2.2*2", "4.4")]
        [DataRow("2.25*-2.25", "-5.0625")]
        [DataRow("-22.1*5.5", "-121.55")]
        [DataRow("-1.1*-4.9", "5.39")]
        [DataRow("0.0*2.0", "0")]
        [DataRow("0.0*0.0", "0")]
        [TestMethod]
        public void MultiplyDoubles(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [DataRow("2/2", "1")]
        [DataRow("2/-2", "-1")]
        [DataRow("-2/5", "-0.4")]
        [DataRow("-2/-4", "0.5")]
        [DataRow("0/2", "0")]
        [TestMethod]
        public void DivideIntegers(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [DataRow("2.2/2", "1.1")]
        [DataRow("2.25/-2.25", "-1")]
        [DataRow("-22.1/5.5", "-4.0182")]
        [DataRow("-1.1/-4.9", "0.2245")]
        [DataRow("0.0/2.0", "0")]
        [TestMethod]
        public void DivideDoubles(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }


        [DataRow("2%2", "0")]
        [DataRow("2%-2", "0")]
        [DataRow("-2%5", "-2")]
        [DataRow("-2%-4", "-2")]
        [DataRow("0%2", "0")]
        [DataRow("0%0", "NaN")]
        [TestMethod]
        public void ModulusIntegers(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [DataRow("2.2%2", "0.2")]
        [DataRow("2.25%-1.15", "1.1")]
        [DataRow("-22.1%5.5", "-0.1")]
        [DataRow("-1.1%-4.9", "-1.1")]
        [DataRow("0.0%2.0", "0")]
        [TestMethod]
        public void ModulusDoubles(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [DataRow("2^2", "4")]
        [DataRow("2^-2", "0.25")]
        [DataRow("-2^5", "-32")]
        [DataRow("-2^-4", "0.0625")]
        [DataRow("0^2", "0")]
        [DataRow("0^0", "1")]
        [TestMethod]
        public void ExponentIntegers(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

        [DataRow("2.2^2", "4.84")]
        [DataRow("2.25^-1.15", "0.3935")]
        [DataRow("22.1^5.5", "24783207.0546")]
        [DataRow("-1.1^-4.9", "NaN")]
        [DataRow("0.0^2.0", "0")]
        [TestMethod]
        public void ExponentDoubles(string line, string result)
        {

            string answer = $"{line} = {result}";
            string exitLine = "exit";
            string expectedOutput = $@">>Enter 'exit' to end program.
Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{line}
>>{answer}
>>Enter binomial math operation to solve. e.g. (-2.5%5.1): <<{exitLine}
>>Program complete.";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, StringMath.StringMath.Main);
        }

    }//Binomial Evaluation Unit Tests


    

}


    
