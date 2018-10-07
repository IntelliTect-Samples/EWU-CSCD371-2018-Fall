using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment2Tests
{
    [TestClass]
    public class StringsTest
    {
        [TestMethod]
        public void TestAdditionZero()
        {
            string nmbr = "3+0";
            string expectedOutput = $@">>{nmbr}
<<3";
            
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestAdditionNegative()
        {
            string nmbr = "3 + -2";
            string expectedOutput = $@">>{nmbr}
<<1";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestAdditionMinValue()
        {
            int nmbr = 3 + int.MinValue;
            string expectedOutput = $@">>{nmbr}
<<-2147483645";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestAdditionMaxValue()
        {
            int nmbr = 0 + int.MaxValue;
            string expectedOutput = $@">>{nmbr}
<<2147483647";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }



        [TestMethod]
        public void TestSubtractionZero()
        {
            string nmbr = "3 - 0";
            string expectedOutput = $@">>{nmbr}
<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestSubtractionNegative()
        {
            string nmbr = "3 - -2";
            string expectedOutput = $@">>{nmbr}
<<5";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestSubtractionMinValue()
        {
            int nmbr = -1 - int.MinValue;
            string expectedOutput = $@">>{nmbr}
<<2147483647";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestSubtractionMaxValue()
        {
            int nmbr = 3 - int.MaxValue;
            string expectedOutput = $@">>{nmbr}
<<-2147483644";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestMultiplyZero()
        {
            string nmbr = "3 + 0";
            string expectedOutput = $@">>{nmbr}
<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestMultiplyNegative()
        {
            string nmbr = "3 + -2";
            string expectedOutput = $@">>{nmbr}
<<1";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestMultiplyMinValue()
        {
            int nmbr = 3 + int.MinValue;
            string expectedOutput = $@">>{nmbr}
<<-2147483645";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestMultiplyMaxValue()
        {
            int nmbr = 0 + int.MaxValue;
            string expectedOutput = $@">>{nmbr}
<<2147483647";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }



        [TestMethod]
        public void TestDivisionZero()
        {
            string nmbr = "3 - 0";
            string expectedOutput = $@">>{nmbr}
<<3";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestDivisionNegative()
        {
            string nmbr = "3 - -2";
            string expectedOutput = $@">>{nmbr}
<<5";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestDivisionMinValue()
        {
            int nmbr = -1 - int.MinValue;
            string expectedOutput = $@">>{nmbr}
<<2147483647";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }

        [TestMethod]
        public void TestDivisionMaxValue()
        {
            int nmbr = 3 - int.MaxValue;
            string expectedOutput = $@">>{nmbr}
<<-2147483644";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput, Assignment2.UserInputExpression.UserInput);
        }
    }
}
