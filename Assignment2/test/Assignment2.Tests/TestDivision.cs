using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment2.Tests
{
    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void TestDiv12And3HardCoded()
        {
            string expectedOuput = $@">>Please enter a calculation to perform: <<12/3
>>12/3 = 4
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestDivNeg2And2()
        {
            int num1 = -2;
            int num2 = 2;
            int res = num1 / num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}/{num2}
>>{num1}/{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestDiv15And4()
        {
            int num1 = 15;
            int num2 = 4;
            int res = num1 / num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}/{num2}
>>{num1}/{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestDiv3And2()
        {
            int num1 = 3;
            int num2 = 2;
            int res = num1 / num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}/{num2}
>>{num1}/{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestDiv3And0()
        {
            int num1 = 3;
            int num2 = 0;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}/{num2}
>>Cannot Divide by Zero - Please Try Again
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestDivNeg2And0()
        {
            int num1 = -2;
            int num2 = 0;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}/{num2}
>>Cannot Divide by Zero - Please Try Again
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestDivMinValAnd2()
        {
            int num1 = int.MinValue;
            int num2 = 2;
            int res = num1 / num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}/{num2}
>>{num1}/{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestDivMaxValAnd2()
        {
            int num1 = int.MaxValue;
            int num2 = 2;
            int res = num1 / num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}/{num2}
>>{num1}/{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }
    }
}
