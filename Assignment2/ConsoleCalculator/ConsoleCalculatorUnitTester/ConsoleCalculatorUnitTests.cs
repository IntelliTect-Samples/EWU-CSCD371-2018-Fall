using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrianBosAssignment2Namespace
{
    [TestClass]
    public class ConsoleCalculatorUnitTests
    {
        [TestMethod]
        public void TestAddition()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 + 2\n>>Result: 3\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestAdditionWhitespace()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1+2\n>>Result: 3\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 +2\n>>Result: 3\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1+ 2\n>>Result: 3\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1   +    2\n>>Result: 3\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<   1+2   \n>>Result: 3\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestNegativeAdditionWhitespace()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-1 + -2\n>>Result: -3\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<  -1+-2   \n>>Result: -3\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<   -1+2   \n>>Result: 1\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestSubtraction()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<123 - 456\n>>Result: -333\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<456 - 123\n>>Result: 333\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestNegativeSubtraction()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-123 - -456\n>>Result: 333\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-456 - 123\n>>Result: -579\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestMultiplication()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<360 * 420\n>>Result: 151200\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<360 * 0\n>>Result: 0\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestNegativeMultiplication()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<360 * -420\n>>Result: -151200\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-360 * 420\n>>Result: -151200\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-360 * -420\n>>Result: 151200\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<360 * -0\n>>Result: 0\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestDivision()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<108 / 12\n>>Result: 9\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<5 / 2\n>>Result: 2\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1080 / 1080\n>>Result: 1\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<0 / 1080\n>>Result: 0\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestDivisionByZero()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 / 0\n>>Error: Division by zero\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 / -0\n>>Error: Division by zero\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestNegativeDivision()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<0 / -1080\n>>Result: 0\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-1080 / -1080\n>>Result: 1\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1080 / -1080\n>>Result: -1\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect("ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-5 / 2\n>>Result: -2\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestResultOverflow()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<2147483647 + 0\n>>Result: 2147483647\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<2147483647 + 1\n>>Error: Integer overflow\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-2147483647 - 1\n>>Result: -2147483648\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-2147483647 - 2\n>>Error: Integer overflow\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestOperandOverflow()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<9999999999 + 1\n>>Error: An operand was larger than {int.MaxValue} or smaller than or equal to {int.MinValue} (int.MaxValue and int.MinValue, respectively)\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-9999999999 - 1\n>>Error: An operand was larger than {int.MaxValue} or smaller than or equal to {int.MinValue} (int.MaxValue and int.MinValue, respectively)\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 + 9999999999\n>>Error: An operand was larger than {int.MaxValue} or smaller than or equal to {int.MinValue} (int.MaxValue and int.MinValue, respectively)\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 - -9999999999\n>>Error: An operand was larger than {int.MaxValue} or smaller than or equal to {int.MinValue} (int.MaxValue and int.MinValue, respectively)\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }

        [TestMethod]
        public void TestMalformedEquation()
        {
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1\n>>Error: Invalid equation (stringPosition >= equationString.Length in method getOperand())\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1+\n>>Error: Invalid equation (stringPosition >= equationString.Length in method getOperand())\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 +\n>>Error: Invalid equation (stringPosition >= equationString.Length in method getOperand())\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 + \n>>Error: Invalid equation (stringPosition >= equationString.Length in method getOperand())\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 + 1 \n>>Result: 2\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 + 1 + 1\n>>Warning: This application only supports 2 operands. All characters after the second operand were ignored.\nResult: 2\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 + a\n>>Invalid character \"a\" found at position 4 of the equation string.\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<a + 1\n>>Invalid character \"a\" found at position 0 of the equation string.\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 + -a\n>>Invalid character \"a\" found at position 5 of the equation string.\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-a + 1\n>>Invalid character \"a\" found at position 1 of the equation string.\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<Lemon Custard\n>>Invalid character \"L\" found at position 0 of the equation string.\nInvalid character \"e\" found at position 1 of the equation string.\nInvalid character \"m\" found at position 2 of the equation string.\nInvalid character \"o\" found at position 3 of the equation string.\nInvalid character \"n\" found at position 4 of the equation string.\nInvalid character \"C\" found at position 6 of the equation string.\nInvalid character \"u\" found at position 7 of the equation string.\nInvalid character \"s\" found at position 8 of the equation string.\nInvalid character \"t\" found at position 9 of the equation string.\nInvalid character \"a\" found at position 10 of the equation string.\nInvalid character \"r\" found at position 11 of the equation string.\nInvalid character \"d\" found at position 12 of the equation string.\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 ++ 1\n>>Warning: This application only supports 2 operands. All characters after the second operand were ignored.\nResult: 1\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<- - -\n>>Error: A lonely negative sign has made its way into getOperand()\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<+*+**+*+**+* *+*+*+*+*\n>>Warning: This application only supports 2 operands. All characters after the second operand were ignored.\nResult: 0\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<-+-\n>>Error: A lonely negative sign has made its way into getOperand()\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<- + -\n>>Error: A lonely negative sign has made its way into getOperand()\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1\t1\t\n>>Invalid character \"\t\" found at position 1 of the equation string.\nInvalid character \"\t\" found at position 3 of the equation string.\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect($"ConsoleCalculator is now running.\nEnter \"Bye\" to quit the program.\n\nEnter an expression to evaluate: <<1 % 1\n>>Invalid character \"%\" found at position 2 of the equation string.\n\nEnter an expression to evaluate: <<Bye\n", ConsoleCalculator.Main);
        }
    }

    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void TestStringCompare()
        {
            Assert.AreNotEqual(0, string.Compare("Lemon Custard", "Lemon custard"));
        }

        [TestMethod]
        public void TestStringReplace()
        {
            string testString = "?uoy tuoba woH .inoracam ym ni dratsuc nomel ekil I";
            Assert.AreEqual("?uoytuobawoH.inoracamymnidratsucnomelekilI", testString.Replace(" ", ""));
        }

        [TestMethod]
        public void TestStringToString()
        {
            string testString = "TEST";
            Assert.AreEqual(testString.ToString(), "TEST");
        }

        [TestMethod]
        public void TestStringArrayIndexAccess()
        {
            string testString = "€x „'?€  Ó#ƒ,SL"; // The string does actually have a lot of strange characters in it. This is intentional
            Assert.AreEqual('\'', testString[5]);
        }
    }
}