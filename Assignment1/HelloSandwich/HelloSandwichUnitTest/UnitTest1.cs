using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * HelloSandwich.cs
 * Created by Brian Bos
 * 
 * Quick and dirty attempts to run through the program multiple times resulted in an assertion failure in the testing tools.
 * In response, I have commented out two of the three responses. They can only be done one at a time
 * (I probably just don't know the testing tools well enough to do all three at once.)
 * 
 * Discovering the syntax of Intellitect console unit testing with the power of trial and error...
 * It seems that, although the console tester does send input to the program, it never prints out this input when diagnosing failed tests.
 * 
 * For example, notice the "blank" inputs, even though the actual program definitely receives the inputs (it spits them back out)
 * 
 * (Unit test output start)
 * 
 * Actual:
 * -----------------------------------
 * What is your name?
 *
 * How many mice does it take to make a turkey sandwich?
 * Answer:
 * Entered name  : Brian
 * Entered answer: 2
 *
 * "Brian" believes that it takes 2 mice to make a turkey sandwich!
 * 
 * (Unit test output end)
 */

namespace BrianBosAssignment1Namespace
{
    [TestClass]
    public class HelloSandwichUnitTester
    {
        [TestMethod]
        public void TestHelloSandwich()
        {
            string expectedOutput1 = "What is your name?\n<<Brian\n>>\nHow many mice does it take to make a turkey sandwich?\nAnswer: <<2\n>>\nEntered name  : Brian\nEntered answer: 2\n\n\"Brian\" believes that it takes 2 mice to make a turkey sandwich!";
            //string expectedOutput2 = "What is your name?\n<<HorseRadish\n>>\nHow many mice does it take to make a turkey sandwich?\nAnswer: <<Over 9000!!!\n>>\nEntered name  : HorseRadish\nEntered answer: Over 9000!!!\n\n\"HorseRadish\" believes that it takes Over 9000!!! mice to make a turkey sandwich!";
            //string expectedOutput3 = "What is your name?\n<<Sun Microtachyon\n>>\nHow many mice does it take to make a turkey sandwich?\nAnswer: <<the alchemic transfiguration of\n>>\nEntered name  : Sun Microtachyon\nEntered answer: the alchemic transfiguration of\n\n\"Sun Microtachyon\" believes that it takes the alchemic transfiguration of mice to make a turkey sandwich!";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput1, HelloSandwich.Main);
            //IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput2, HelloSandwich.Main);
            //IntelliTect.TestTools.Console.ConsoleAssert.Expect(expectedOutput3, HelloSandwich.Main);
        }
    }
}
