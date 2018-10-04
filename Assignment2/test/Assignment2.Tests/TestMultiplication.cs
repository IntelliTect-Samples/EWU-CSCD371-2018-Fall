using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment2.Tests
{
    [TestClass]

    public class TestMultiplication
    {
        [TestMethod]
        public void TestMult4And7HardCoded()
        {
            string expectedOuput = $@">>Please enter a calculation to perform: <<4*7
>>4*7 = 28
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestMult0And15HardCoded()
        {
            int num1 = -2;
            int num2 = 40;
            int res = num1 * num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<0*15
>>0*15 = 0
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestMultNeg2And40()
        {
            int num1 = -2;
            int num2 = 40;
            int res = num1 * num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}*{num2}
>>{num1}*{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestMult8AndNeg20()
        {
            int num1 = 8;
            int num2 = 20;
            int res = num1 * num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}*{num2}
>>{num1}*{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestMultNeg13AndNeg4()
        {
            int num1 = -13;
            int num2 = -4;
            int res = num1 * num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}*{num2}
>>{num1}*{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestMultMinValAnd5()
        {
            int num1 = int.MinValue;
            int num2 = 5;
            int res = num1 * num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}*{num2}
>>{num1}*{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestMultMaxValAnd7()
        {
            int num1 = int.MaxValue;
            int num2 = 7;
            int res = num1 * num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}*{num2}
>>{num1}*{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestMultMaxValAndZero()
        {
            int num1 = int.MaxValue;
            int num2 = 0;
            int res = num1 * num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}*{num2}
>>{num1}*{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }
    }
}
