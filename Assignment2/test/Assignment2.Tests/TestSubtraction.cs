using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment2.Tests
{
    [TestClass]
    public class TestSubtraction
    {
        [TestMethod]
        public void TestSub8And2HardCoded()
        {
            string expectedOuput = $@">>Please enter a calculation to perform: <<8-2
>>8-2 = 6
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestSub297And43()
        {
            int num1 = 297;
            int num2 = 43;
            int res = num1 - num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}-{num2}
>>{num1}-{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestSubNeg4And16()
        {
            int num1 = -4;
            int num2 = 16;
            int res = num1 - num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}-{num2}
>>{num1}-{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestSub5AndNeg12()
        {
            int num1 = 5;
            int num2 = -12;
            int res = num1 - num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}-{num2}
>>{num1}-{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestSubNeg2AndNeg4()
        {
            int num1 = -2;
            int num2 = -4;
            int res = num1 - num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}-{num2}
>>{num1}-{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestSubNeg2AndMaxVal()
        {
            int num1 = -2;
            int num2 = int.MaxValue;
            int res = num1 - num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}-{num2}
>>{num1}-{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestSubMaxValAnd4()
        {
            int num1 = int.MaxValue;
            int num2 = 4;
            int res = num1 - num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}-{num2}
>>{num1}-{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestSub0And4()
        {
            int num1 = 0;
            int num2 = 4;
            int res = num1 - num2;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{num1}-{num2}
>>{num1}-{num2} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestSub0And7HardCoded()
        { 
            string expectedOuput = $@">>Please enter a calculation to perform: <<0-7
>>0-7 = -7
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }
    }
}
