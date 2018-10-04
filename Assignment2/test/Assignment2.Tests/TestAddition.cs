using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment2.Tests
{
    [TestClass]
    public class TestAddition
    {
        [TestMethod]
        public void TestAdd8And2HardCoded()
        {
            string expectedOuput = $@">>Please enter a calculation to perform: <<8+2
>>8+2 = 10
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestAdd6And90HardCoded()
        {
            string expectedOuput = $@">>Please enter a calculation to perform: <<6+90
>>6+90 = 96
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestAddMinAnd5()
        {
            int minVal = int.MinValue;
            int five = 5;
            int res = minVal + five;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{minVal}+{five}
>>{minVal}+{five} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestAddMaxAndNeg7()
        {
            int maxVal = int.MaxValue;
            int negSeven = -7;
            int res = maxVal + negSeven;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{maxVal}+{negSeven}
>>{maxVal}+{negSeven} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }

        [TestMethod]
        public void TestAdd0AndNeg7()
        {
            int zero = 0;
            int negSeven = -7;
            int res = zero + negSeven;

            string expectedOuput = $@">>Please enter a calculation to perform: <<{zero}+{negSeven}
>>{zero}+{negSeven} = {res}
>>Press Enter to Exit Program . . .";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOuput, Assignment2.Program.Main);
        }
    }
}